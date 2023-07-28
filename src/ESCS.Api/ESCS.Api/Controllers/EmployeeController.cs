using ESCS.Api.Dto;
using ESCS.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IEmpProjJuncRepo _empProjJuncRepo;
        private readonly IProjectRepo _projectRepo;

        public EmployeeController(IEmployeeRepo employeeRepo, IEmpProjJuncRepo empProjJuncRepo, IProjectRepo projectRepo)
        {
            _employeeRepo = employeeRepo;
            _empProjJuncRepo = empProjJuncRepo;
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            var employees = _employeeRepo.GetAllEmployees();
            var empProjJuncs = _empProjJuncRepo.GetAllEmpProjJuncs();
            employees.ForEach(emp =>
            {
                var projectIds = empProjJuncs.Where(junc => junc.EmpId == emp.Id).Select(junc => junc.ProjectId);
                var projects = _projectRepo.GetAllProjects().Where(p => projectIds.Contains(p.Id));
                var empDto = new EmployeeDto
                {
                    Name = emp.Name,
                    Projects = projects.ToList()
                };
                employeeDtos.Add(empDto);
            });

            return employeeDtos;
        }
    }
}
