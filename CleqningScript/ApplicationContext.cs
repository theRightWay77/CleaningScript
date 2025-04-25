using CleaningScript.Models;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SlanovaHP;Initial Catalog=COPP;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
