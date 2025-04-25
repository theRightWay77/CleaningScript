using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningScript.Models
{
    public class EntityFiles
    {
        private static ApplicationContext db = new ApplicationContext();
        public void GetAllEntityFiles()
        {
            
                Console.WriteLine("=== EntityFiles ===\n");
                Console.WriteLine($"{"№",-4} {"ID",-36} {"Name",-20} {"EntityType",-15} {"EntityId",-36}");
                Console.WriteLine(new string('-', 115));

                int i = 1;
                var entityFiles = db.EntityFiles.ToList();
                foreach (var u in entityFiles)
                {
                    Console.WriteLine($"{i++,-4} {u.Id,-20} {u.Name,-20} {u.EntityType,-15} {u.EntityId,-36}");
                }
        }

        public void GetOrphaned()
        {
            Console.WriteLine($"{"№",-4} {"ID",-36} {"Name",-20} {"EntityType",-15} {"EntityId",-36}");
            Console.WriteLine(new string('-', 115));

            var entityFiles = db.EntityFiles.ToList();
            var modelus = db.Modules.ToList();
            var lessons = db.EntityFiles.ToList();
        }
    }
}
