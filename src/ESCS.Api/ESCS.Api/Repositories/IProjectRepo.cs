using ESCS.Api.Dto;
using ESCS.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Repositories
{
    public interface IProjectRepo
    {
        List<Project> GetAllProjects();
        List<ProjectDto> GetProjects(int empId);
    }
}
