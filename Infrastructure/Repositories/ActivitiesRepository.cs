using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaizen.Domain.Data;
using Kaizen.Domain.Entities;
using Kaizen.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Kaizen.Infrastructure.Repositories
{
    public class ActivitiesRepository : RepositoryBase<Activity, int>, IActivitiesRepository
    {
        private readonly DateTime LIMIT_DATE = DateTime.Parse($"{DateTime.Now.Year}/12/31");
        private readonly IEmployeesRepository _employeesRepository;

        public ActivitiesRepository(ApplicationDbContext applicationDbContext, IEmployeesRepository employeesRepository) : base(applicationDbContext)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task ScheduleActivities(Activity activity)
        {
            if (activity.Periodicity == PeriodicityType.Casual)
                return;

            int dayInterval = GetDayInterval(activity.Periodicity);
            if (dayInterval == -1)
                return;

            string[] activityServiceCodes = activity.ActivitiesServices.Select(s => s.ServiceCode).ToArray();
            List<string> activityEmployeeCodes = activity.ActivitiesEmployees.Select(a => a.EmployeeId).ToList();

            DateTime newDate = activity.Date.AddDays(dayInterval);
            while (newDate < LIMIT_DATE)
            {
                Activity newActivity = activity.Clone() as Activity;
                IEnumerable<Employee> availableEmployees = await GetTechniciansAvailable(newActivity.Date, activityServiceCodes);
                bool canBeScheduled = ActivityCanBeScheduled(activityEmployeeCodes, availableEmployees);
                while (!canBeScheduled)
                {
                    newActivity.Date = newActivity.Date.AddHours(1);
                    availableEmployees = await GetTechniciansAvailable(newActivity.Date, activityServiceCodes);
                    canBeScheduled = ActivityCanBeScheduled(activityEmployeeCodes, availableEmployees);
                }

                Insert(newActivity);
                newDate = newDate.AddDays(dayInterval);
            }

            await ApplicationDbContext.SaveChangesAsync();
        }

        private static bool ActivityCanBeScheduled(List<string> activityEmployeeCodes, IEnumerable<Employee> availableEmployees)
        {
            return activityEmployeeCodes.All(e => availableEmployees.Any(a => activityEmployeeCodes.Contains(a.Id)));
        }

        private async Task<IEnumerable<Employee>> GetTechniciansAvailable(DateTime date, string[] serviceCodes)
        {
            return await _employeesRepository.GetTechniciansAvailable(date, serviceCodes);
        }

        private static int GetDayInterval(PeriodicityType periodicityType)
        {
            return periodicityType switch
            {
                PeriodicityType.Biweekly => 15,
                PeriodicityType.Monthly => 30,
                PeriodicityType.BiMonthly => 60,
                PeriodicityType.Trimester => 90,
                PeriodicityType.Quarter => 120,
                PeriodicityType.FiveMonths => 150,
                PeriodicityType.Biannual => 180,
                PeriodicityType.Annual => 360,
                _ => -1,
            };
        }

        public override async Task<Activity> FindByIdAsync(int id)
        {
            return await ApplicationDbContext.Activities.Include(a => a.Client)
                .Include(a => a.ActivitiesServices)
                .ThenInclude(a => a.Service)
                .Include(a => a.ActivitiesEmployees).ThenInclude(a => a.Employee)
                .Where(a => a.Code == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Activity>> GetPendingEmployeeActivities(string employeeId, DateTime date)
        {
            return await GetAll().Include(a => a.ActivitiesEmployees).Include(a => a.Client)
                .Where(a => a.State == ActivityState.Pending &&
                       a.Date.Month == date.Month && a.Date.Day == date.Day &&
                       a.ActivitiesEmployees.Select(a => a.EmployeeId).Contains(employeeId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetPendingClientActivities(string clientId)
        {
            return await GetAll().Include(a => a.ActivitiesServices).ThenInclude(a => a.Service)
                .Include(a => a.ActivitiesEmployees).ThenInclude(a => a.Employee)
                .Where(a => a.State == ActivityState.Pending && a.ClientId == clientId)
                .ToListAsync();
        }
    }
}
