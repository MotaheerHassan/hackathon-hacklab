using ESCS.Api.Dto;
using ESCS.Api.Entities;
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
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IEmpProjJuncRepo _empProjJuncRepo;
        private readonly IProjectRepo _projectRepo;
        private readonly ISkillRepo _skillRepo;

        public EmployeeController(IEmployeeRepo employeeRepo, IEmpProjJuncRepo empProjJuncRepo, IProjectRepo projectRepo, ISkillRepo skillRepo)
        {
            _employeeRepo = employeeRepo;
            _empProjJuncRepo = empProjJuncRepo;
            _projectRepo = projectRepo;
            _skillRepo = skillRepo;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            var employees = _employeeRepo.GetAllEmployees();
            var empProjJuncs = _empProjJuncRepo.GetAllEmpProjJuncs();
            employees.Data.ForEach(emp =>
            {
                var projectIds = empProjJuncs.Where(junc => junc.EmpId == emp.Id).Select(junc => junc.ProjectId);
                var projects = _projectRepo.GetAllProjects().Where(p => projectIds.Contains(p.Id));
                var empDto = new EmployeeDto
                {
                    Name = emp.Name,
                    //Skills =              
                    //Projects = 
                };
                employeeDtos.Add(empDto);
            });

            return employeeDtos;
        }

        [HttpGet("all")]
        public List<EmployeeDto> GetAll()
        {
            var res = new List<EmployeeDto>();
            var emps = _employeeRepo.GetAllEmployees();
            if(emps.Status == 1 && emps.Data.Count > 0)
            {
                emps.Data.ForEach(emp =>
                {
                    res.Add(_employeeRepo.GetEmployeeProfile(emp.Id));
                }
                );
            }

            return res;
        }

        [HttpGet("projects/{empId}")]
        public List<ProjectDto> GetProjects(int empId)
        {
            return _projectRepo.GetProjects(empId);
        }

        [HttpGet("employee/{empId}")]
        public EmployeeDto GetEmployeeProfile(int empId)
        {
            var empProjects = _projectRepo.GetProjects(empId);
            var empSkills = _skillRepo.GetSkills(empId);
            var employeeData = _employeeRepo.GetEmployee(empId);

            if(employeeData.Status == 1 && employeeData.Data != null)
            {
                return new EmployeeDto
                {
                    Name = employeeData.Data.Name,
                    AreaOfInterests = employeeData.Data.AreaOfInterests,
                    Projects = empProjects,
                    Skills = empSkills,
                    YOE = employeeData.Data.YOE
                };
            }

            return null;

        }

        [HttpGet("get/{empId}")]
        public EmployeeDto GetEmployeeProfile2(int empId)
        {
            return _employeeRepo.GetEmployeeProfile(empId);

        }

        [HttpPost("addupdate")]
        public bool AddUpdateEmployee([FromBody]EmployeeDto employeeDto)
        {
            var empProjects = employeeDto.Projects;
            var skills = employeeDto.Skills;

            var projectsUpdated = _employeeRepo.AddUpdateEmployee(new Entities.Employee {
                Id = 4,
                Projects = new List<Project>()
                {

                    new Project { Id = 8, Name = "UpdatedName"},
                     new Project { Name = "NewProj1"}
                }
            });
            return true;
        }

    }
}
