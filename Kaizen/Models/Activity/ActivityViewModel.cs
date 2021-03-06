using System.Collections.Generic;
using Kaizen.Models.Client;
using Kaizen.Models.Employee;
using Kaizen.Models.Service;

namespace Kaizen.Models.Activity
{
    public class ActivityViewModel : ActivityInputModel
    {
        public int Code { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }
        public List<ServiceViewModel> Services { get; set; }
        public ClientViewModel Client { get; set; }
    }
}
