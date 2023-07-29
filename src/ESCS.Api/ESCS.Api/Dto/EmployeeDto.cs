using ESCS.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string CurrentDesignation { get; set; }
        public int YOE { get; set; }
        public string AreaOfInterests { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<SkillDto> Skills { get; set; }

    }
}
