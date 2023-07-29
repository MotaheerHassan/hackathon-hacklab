﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Entities
{
    public class EmpSkillJunc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssociationId { get; set; }
        public int EmpId { get; set; }
        public int SkillId { get; set; }
        public int YOE { get; set; }
    }
}
