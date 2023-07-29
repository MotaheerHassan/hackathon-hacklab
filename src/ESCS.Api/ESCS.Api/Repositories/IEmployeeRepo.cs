using ESCS.Api.Dto;
using ESCS.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Repositories
{
    public interface IEmployeeRepo
    {
        APIModel<List<Employee>> GetAllEmployees();
        APIModel<bool> AddEmployee(Employee emp);
        APIModel<Employee> GetEmployee(int id);
    }
}
