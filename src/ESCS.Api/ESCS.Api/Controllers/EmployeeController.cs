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

        //[HttpPost]
        //public bool AddUpdateProjects(int empId, List<ProjectDto> projectDtos)
        //{
        //    var allProjectIdsofEmp = _empProjJuncRepo.GetAllProjectsOfAEmp(empId).Select(junc => junc.ProjectId);
        //    var addedProjects = projectDtos.Where(dto => !allProjectIdsofEmp.Contains(dto.Id));
        //    var updateProjects = projectDtos.Where(dto => allProjectIdsofEmp.Contains(dto.Id));

        //    _projectRepo.

        //}


    }
}
