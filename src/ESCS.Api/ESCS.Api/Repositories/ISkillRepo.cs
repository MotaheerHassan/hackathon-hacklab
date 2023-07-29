using ESCS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Repositories
{
    public interface ISkillRepo
    {
        List<SkillDto> GetSkills(int empId);
    }
}
