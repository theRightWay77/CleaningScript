using CleaningScript.Models;
using CleqningScript.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningScript
{
    public class ApplicationContext : DbContext
    {
        public DbSet<EntityFile> EntityFiles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<EducationLesson> EducationLessons { get; set; }
        public DbSet<EducationProgram> Programs { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<CompetencyElement> CompetencyElements { get; set; }
        public DbSet<GroupOfCompetences> GroupOfCompetences { get; set; }
        public DbSet<Speсialty> Speсialty { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Compartment> Compartments { get; set; }

        public DbSet<EducationProgramOrder> EducationProgramOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EXPASYS-SLANOVA;Initial Catalog=COPP;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
