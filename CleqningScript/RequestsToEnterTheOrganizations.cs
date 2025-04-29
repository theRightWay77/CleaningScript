using CleaningScript;
using CleqningScript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleqningScript
{
    public class RequestsToEnterTheOrganizations
    {
        private static ApplicationContext db = new ApplicationContext();
        public void GetAll()
        {
            Console.WriteLine("=== RequestToEnterTheOrganization ===\n");
            Console.WriteLine($"{"№",-4} {"ID",-36} {"UserId",-20} {"OrganizationId",-15}");
            Console.WriteLine(new string('-', 115));

            var requests = db.RequestToEnterTheOrganizations.ToList();

            int i = 1;
            foreach (var r in requests)
            {
                Console.WriteLine($"{i++,-4} {r.Id,-20} {r.UserId,-36} {r.OrganizationId,-20}");
            }
            Console.WriteLine();
        }
         public void GetAllWithOrgName()
        {
            Console.WriteLine("=== RequestToEnterTheOrganization ===\n");
            Console.WriteLine($"{"№",-4} {"ID",-20} {"UserId",-20} {"OrganizationId",-15}  {"OrganizationName",-15}");
            Console.WriteLine(new string('-', 115));

            var requests = db.RequestToEnterTheOrganizations.ToList();
            var organizations = db.Organizations.ToList();

            int i = 1;
            foreach (var r in requests)
            {
                var orgName = organizations?.FirstOrDefault(x => x.Id == r.OrganizationId)?.Name;
                Console.WriteLine($"{i++,-4} {r.Id,-20} {r.UserId,-20} {r.OrganizationId,-15} {orgName,-15}");
            }
            Console.WriteLine();
        }

        public void GetOrphaned()
        {
            Console.WriteLine("=== ORPHANED RequestToEnterTheOrganization ===\n");
            Console.WriteLine($"{"№",-4} {"ID",-20} {"UserId",-20} {"OrganizationId",-15}");
            Console.WriteLine(new string('-', 115));

            var orphaned = new List<RequestToEnterTheOrganization>();

            var requests = db.RequestToEnterTheOrganizations.ToList();
            var organizations = db.Organizations.ToList();

            foreach (var r in requests)
            {
                if (!organizations.Any(org => r.OrganizationId == org.Id))
                {
                    orphaned.Add(r);
                }
                //else
                //{
                //    Console.WriteLine(organizations.FirstOrDefault(o => o.Id == r.OrganizationId));
                //}
            }

            int i = 1;
            foreach (var r in orphaned)
            {
                Console.WriteLine($"{i++,-4} {r.Id,-20} {r.UserId,-20} {r.OrganizationId,-15}");
            }
            Console.WriteLine();
        }
    }
}
