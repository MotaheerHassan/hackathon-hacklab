using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESCS.Api.Entities;
using Microsoft.EntityFrameworkCore;


namespace ESCS.Api.Contexts
{
    public class ESCSDBContext : DbContext
    {
        public ESCSDBContext(DbContextOptions<ESCSDBContext> options)
        : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        //public DbSet<ProjectSkillJunc> ProjectSkillJuncs { get; set; }
        //public DbSet<EmpSkillJunc> empSkillJuncs { get; set; }
        public DbSet<ProjEmpJunc> ProjEmpJuncs { get; set; }
        public DbSet<EmpSkillProjJunc> EmpSkillProjJuncs { get; set; }
    }
}
