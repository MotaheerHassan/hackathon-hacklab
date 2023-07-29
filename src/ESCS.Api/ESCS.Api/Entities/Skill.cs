using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Entities
{
    public class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name
        {
            get; set;
        }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
