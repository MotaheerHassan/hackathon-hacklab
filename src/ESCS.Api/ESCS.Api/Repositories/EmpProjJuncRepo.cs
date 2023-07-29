using ESCS.Api.Contexts;
using ESCS.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Repositories
{
    public class EmpProjJuncRepo : IEmpProjJuncRepo
    {
        private readonly ESCSDBContext _eSCSDBContext;

        public EmpProjJuncRepo(ESCSDBContext eSCSDBContext)
        {
            _eSCSDBContext = eSCSDBContext;
        }
        public List<ProjEmpJunc> GetAllEmpProjJuncs()
        {
            return _eSCSDBContext.ProjEmpJuncs.ToList();
        }

        public List<ProjEmpJunc> GetAllEmpIdsInAproject(int projId)
        {
            return _eSCSDBContext.ProjEmpJuncs.Where(junc => junc.ProjectId == projId).ToList();
        }

        public List<ProjEmpJunc> GetAllProjectsOfAEmp(int empId)
        {
            return _eSCSDBContext.ProjEmpJuncs.Where(junc => junc.EmpId == empId).ToList();
        }
    }
}
