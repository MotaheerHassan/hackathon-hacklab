using ESCS.Api.Contexts;
using ESCS.Api.Dto;
using ESCS.Api.Entities;
using Microsoft.EntityFrameworkCore;
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
                apiModel.Data = _eSCSDBContext.Employees.Include(e => e.Projects).Include(e => e.Skills).ToList();
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

        public APIModel<bool> AddUpdateEmployee(Employee emp)
        {
            var apiModel = new APIModel<bool>();
            try
            {
                var empToUpdate = _eSCSDBContext.Employees.Include(e =>e.Projects).Include(e => e.Skills).FirstOrDefault(e => e.Id == emp.Id);
                if (empToUpdate != null)
                {
                    var projects = empToUpdate.Projects;
                    foreach (var item in emp.Projects.ToList())
                    {
                        var projFound = projects.FirstOrDefault(p => p.Id == item.Id);
                        if (projFound != null)
                        {
                            projFound.Name = item.Name;
                        }
                        else
                        {
                            empToUpdate.Projects.Add(new Project { Name = item.Name });
                        }
                    }

                    var skills = empToUpdate.Skills;
                    if (skills.Count > 0)
                    {
                        foreach (var item in emp.Skills.ToList())
                        {
                            var skillFound = skills.FirstOrDefault(p => p.Id == item.Id);
                            if (skillFound != null)
                            {
                                skillFound.Name = item.Name;
                            }
                            else
                            {
                                empToUpdate.Skills.Add(new Skill { Name = item.Name });
                            }
                        }
                    }

                    _eSCSDBContext.Update(empToUpdate);
                }
                else
                {
                    var added = new Employee
                    {
                        Name = emp.Name,
                        Projects = emp.Projects
                    };
                    _eSCSDBContext.Add(added);
                }
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

        public EmployeeDto GetEmployeeProfile(int empId)
        {
            var dto = new EmployeeDto();
            var empFound = _eSCSDBContext.Employees.Include(e => e.Projects).Include(e => e.Skills).FirstOrDefault(a => a.Id == empId);
            if(empFound != null)
            {
                var projectsDto = new List<ProjectDto>();
                if(empFound.Projects != null && empFound.Projects.Count > 0)
                {
                    empFound.Projects.ToList().ForEach(p =>
                    {
                        var skillsDto = new List<SkillDto>();
                        if (p.Skills != null && p.Skills.Count > 0)
                        {
                            p.Skills.ToList().ForEach(s =>
                            {
                                skillsDto.Add(new SkillDto
                                {
                                    Id = s.Id,
                                    Name = s.Name
                                });
                            }
                            );
                        }
                        projectsDto.Add(new ProjectDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            StartDate = p.StartDate,
                            EndDate = p.EndDate,
                            Skills = skillsDto
                        });
                    }
                    );
                }
                var skillDto = new List<SkillDto>();
                if (empFound.Skills != null && empFound.Skills.Count > 0)
                {

                    empFound.Skills.ToList().ForEach(s =>
                    {
                        skillDto.Add(new SkillDto
                        {
                            Id = s.Id,
                            Name = s.Name
                        });
                    });
                }
                dto = new EmployeeDto
                {
                    Name = empFound.Name,
                    AreaOfInterests = empFound.AreaOfInterests,
                    Projects = projectsDto,
                    Skills = skillDto
                };

                return dto;
            }
            else
            {
                return null;
            }
        }

        public APIModel<bool> AddUpdateProjects(int empId, List<Project> projects)
        {
            var apiModel = new APIModel<bool>();
            try
            {
                 var emp = _eSCSDBContext.Employees.FirstOrDefault(e => e.Id == empId);
                _eSCSDBContext.SaveChanges();
                apiModel.Data = true;
                apiModel.Status = 1;
                return apiModel;
            }
            catch (Exception ex)
            {
                apiModel.Status = 0;
                apiModel.Error = new Error(ex.Message, ex.ToString());
                return apiModel;
            }
        }

        public APIModel<bool> AddUpdateEmployeeProfile(EmployeeDto employeeDto)
        {
            var apiModel = new APIModel<bool>();
            try
            {
                var emp = _eSCSDBContext.Employees.FirstOrDefault(e => e.Id == 0);
                _eSCSDBContext.SaveChanges();
                apiModel.Data = true;
                apiModel.Status = 1;
                return apiModel;
            }
            catch (Exception ex)
            {
                apiModel.Status = 0;
                apiModel.Error = new Error(ex.Message, ex.ToString());
                return apiModel;
            }
        }
    }
}
