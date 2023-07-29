using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Entities
{
    public class EmpSkillProjJunc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssociationId { get; set; }
        public int ProjEmpAssociationId { get; set; }
        public Skill Skill { get; set; }
    }
}
