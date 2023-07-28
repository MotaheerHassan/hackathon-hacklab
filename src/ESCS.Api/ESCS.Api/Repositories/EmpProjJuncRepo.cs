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
    }
}
