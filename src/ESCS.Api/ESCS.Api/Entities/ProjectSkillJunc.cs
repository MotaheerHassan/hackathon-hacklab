using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Entities
{
    public class ProjectSkillJunc
    {
        [Key]
        public int AssociationId { get; set; }
        public int ProjectId { get; set; }
        public int SkillId { get; set; }
    }
}
