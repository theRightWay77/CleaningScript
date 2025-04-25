using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningScript.Models
{
    public class EducationLesson
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid ModuleId { get; set; }
    }
}
