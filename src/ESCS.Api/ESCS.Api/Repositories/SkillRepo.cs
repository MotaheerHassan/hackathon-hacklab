using ESCS.Api.Contexts;
using ESCS.Api.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Repositories
{
    public class SkillRepo : ISkillRepo
    {
        private readonly ESCSDBContext _eSCSDBContext;

        public SkillRepo(ESCSDBContext eSCSDBContext)
        {
            _eSCSDBContext = eSCSDBContext;
        }
        public List<SkillDto> GetSkills(int empId)
        {
            var skillDtos = new List<SkillDto>();
            var emp = _eSCSDBContext.Employees.Include(e =>e.Skills).FirstOrDefault(emp => emp.Id == empId);
            if(emp != null)
            {
                emp.Skills.ToList().ForEach(skill =>
                {
                    skillDtos.Add(new SkillDto
                    {
                        Id = skill.Id,
                        Name = skill.Name
                    });
                });
            }

            return skillDtos;
        }
    }
}
