using ESCS.Api.Contexts;
using ESCS.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ESCSDBContext _eSCSDBContext;

        public EmployeeRepo(ESCSDBContext eSCSDBContext)
        {
            _eSCSDBContext = eSCSDBContext;
        }
        public List<Employee> GetAllEmployees()
        {
            return _eSCSDBContext.Employees.ToList();
        }
    }
}
