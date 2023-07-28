using ESCS.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Dto
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
    }
}
