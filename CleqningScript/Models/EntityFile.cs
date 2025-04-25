using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningScript.Models
{
    public class EntityFile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
    }
}
