using ESCS.Api.Contexts;
using ESCS.Api.Dto;
using ESCS.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly ESCSDBContext _eSCSDBContext;

        public ProjectRepo(ESCSDBContext eSCSDBContext)
        {
            _eSCSDBContext = eSCSDBContext;
        }
        public List<Project> GetAllProjects()
        {
            return _eSCSDBContext.Projects.ToList();
        }

        public List<ProjectDto> GetProjects(int empId)
        {
            var projectsData = from projectEmpJuncs in _eSCSDBContext.ProjEmpJuncs
                               join p in _eSCSDBContext.Projects on projectEmpJuncs.ProjectId equals p.Id
                               where projectEmpJuncs.EmpId == empId
                               select new
                               {
                                   projectEmpJuncs.ProjectId,
                                   projectEmpJuncs.HardProblem,
                                   projectEmpJuncs.Role,
                                   projectEmpJuncs.StartDate,
                                   projectEmpJuncs.EndDate,
                                   p.Description,
                                   p.Id,
                                   p.Name,
                                   projectEmpJuncs.AssociationId
                               };

            var projectWithSkills = from projectData in projectsData
                                join empSkillProjJunc in _eSCSDBContext.EmpSkillProjJuncs on projectData.AssociationId equals empSkillProjJunc.ProjEmpAssociationId 
                                select new
                                {
                                    empSkillProjJunc.Skill,
                                    projectData.Description,
                                    projectData.StartDate,
                                    projectData.EndDate,
                                    projectData.Name,
                                    projectData.HardProblem,
                                    projectData.Role,
                                    empSkillProjJunc.Skill.Id,
                                    projectId = projectData.Id
                                };

            Dictionary<int, ProjectDto> projectMap = new Dictionary<int, ProjectDto>();

            projectWithSkills.ToList().ForEach(p => {
                if (projectMap.ContainsKey(p.projectId))
                {
                    projectMap[p.projectId].Skills.Add(new SkillDto { Id = p.Skill.Id, Name = p.Skill.Name });
                }
                else
                {
                    var projectDto = new ProjectDto
                    {
                        Name = p.Name,
                        EndDate = p.EndDate,
                        StartDate = p.StartDate,
                        Skills = new List<SkillDto> { new SkillDto { Id = p.Skill.Id, Name = p.Skill.Name } }
                    };
                    projectMap.Add(p.projectId, projectDto);
                }
            });

            var res = new List<ProjectDto>();
            foreach (var item in projectMap)
            {
                res.Add(item.Value);
            }

            return res;
        }
    }
}
