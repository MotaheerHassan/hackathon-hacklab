using ESCS.Api.Contexts;
using ESCS.Api.Dto;
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
        public APIModel<List<Employee>> GetAllEmployees()
        {
            var apiModel = new APIModel<List<Employee>>();
            try
            {
                apiModel.Data = _eSCSDBContext.Employees.ToList();
                apiModel.Status = 1;
            }
            catch(Exception ex)
            {
                apiModel.Status = 0;
                apiModel.Error = new Error(ex.Message, ex.ToString());
            }

            return apiModel;
        }
        public APIModel<Employee> GetEmployee(int id)
        {
            var apiModel = new APIModel<Employee>();
            try
            {
                apiModel.Data = _eSCSDBContext.Employees.FirstOrDefault(e => e.Id == id);
                apiModel.Status = 1;
            }
            catch (Exception ex)
            {
                apiModel.Status = 0;
                apiModel.Error = new Error(ex.Message, ex.ToString());
            }

            return apiModel;
        }

        public APIModel<bool> AddEmployee(Employee emp)
        {
            var apiModel = new APIModel<bool>();
            try
            {
                _eSCSDBContext.Employees.Add(emp);
                _eSCSDBContext.SaveChanges();
                apiModel.Data = true;
                apiModel.Status = 1;
                return apiModel;
            }
            catch(Exception ex)
            {
                apiModel.Status = 0;
                apiModel.Error = new Error(ex.Message, ex.ToString());
                return apiModel;
            }
        }
    }
}
