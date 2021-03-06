using System.Collections.Generic;
using System.Threading.Tasks;
using Kaizen.Domain.Data;
using Kaizen.Domain.Entities;
using Kaizen.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kaizen.Infrastructure.Repositories
{
    public class WorkOrdersRepository : RepositoryBase<WorkOrder, int>, IWorkOrdersRepository
    {
        public WorkOrdersRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<WorkOrder> FindByIdAsync(int id)
        {
            return await ApplicationDbContext.WorkOrders
                .Include(w => w.Sector)
                .Include(w => w.Employee)
                .FirstOrDefaultAsync(w => w.Code == id);
        }

        public async Task<WorkOrder> FindByActivityCodeAsync(int activityCode)
        {
            return await ApplicationDbContext.WorkOrders
                .Include(w => w.Sector).Include(w => w.Employee)
                .FirstOrDefaultAsync(w => w.ActivityCode == activityCode);
        }

        public async Task<IEnumerable<Sector>> GetSectorsAsync()
        {
            return await ApplicationDbContext.Sectors.ToListAsync();
        }
    }
}
