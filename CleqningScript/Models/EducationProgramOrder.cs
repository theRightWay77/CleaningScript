using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleqningScript.Models
{
    public class EducationProgramOrder
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public int OrganizationId { get; set; }
        public int CuratorId { get; set; }
        public int? ExpertId { get; set; }
    }
}
