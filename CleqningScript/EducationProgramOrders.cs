using CleaningScript;
using CleqningScript.Models;

namespace CleqningScript
{
    public class EducationProgramOrders
    {
        private static ApplicationContext db = new ApplicationContext();
        public void GetAll()
        {
            Console.WriteLine("=== EntityFiles ===\n");
            Console.WriteLine($"{"№",-4} {"ID",-36} {"Name",-20} {"OrganizationId",-15} {"CuratorId",-36}");
            Console.WriteLine(new string('-', 115));

            var orders = db.EducationProgramOrders.ToList();

            int i = 1;
            foreach (var o in orders)
            {
                Console.WriteLine($"{i++,-4} {o.Id,-20} {o.OrderName,-36} {o.OrganizationId,-20} {o.CuratorId,-15}");
            }
            Console.WriteLine();
        }
        public void GetAllWithOrg()
        {
            Console.WriteLine("=== EntityFiles ===\n");
            Console.WriteLine($"{"№",-4} {"ID",-36} {"Name",-20} {"OrganizationId",-15} {"OrganizationName",-36}");
            Console.WriteLine(new string('-', 115));

            var orders = db.EducationProgramOrders.ToList();
            var organizations = db.Organizations.ToList();

            int i = 1;
            foreach (var o in orders)
            {
                var orgName = organizations.FirstOrDefault(x => x.Id == o.OrganizationId).Name;
                Console.WriteLine($"{i++,-4} {o.Id,-20} {o.OrderName,-36} {o.OrganizationId,-20} {orgName,-15}");
            }
            Console.WriteLine();
        }
        public void GetOrphaned()
        {
            Console.WriteLine("=== ORPHANED EntityFiles ===\n");
            Console.WriteLine($"{"№",-4} {"ID",-36} {"Name",-20} {"OrganizationId",-15} {"CuratorId",-36}");
            Console.WriteLine(new string('-', 115));

            var orphaned = new List<EducationProgramOrder>();

            var orders = db.EducationProgramOrders.ToList();
            var organizations = db.Organizations.ToList();

            foreach (var order in orders)
            {
                if (!organizations.Any(org => order.OrganizationId == org.Id))
                {
                    orphaned.Add(order);
                }
            }

            int i = 1;
            foreach (var o in orphaned)
            {
                Console.WriteLine($"{i++,-4} {o.Id,-20} {o.OrderName,-36} {o.OrganizationId,-20} {o.CuratorId,-15}");
            }
            Console.WriteLine();
        }
    }
}
