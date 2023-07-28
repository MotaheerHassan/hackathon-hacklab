using ESCS.Api.Contexts;
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
    }
}
