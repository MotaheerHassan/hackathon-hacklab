﻿using ESCS.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Repositories
{
    public interface IEmpProjJuncRepo
    {
        List<ProjEmpJunc> GetAllEmpProjJuncs();
    }
}
