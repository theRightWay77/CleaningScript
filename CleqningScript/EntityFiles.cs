using CleqningScript.Models;
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
            Console.WriteLine();
        }

        public void GetOrphaned()
        {
            Console.WriteLine("=== ORPHANED EntityFiles ===\n");
            Console.WriteLine($"{"№",-4} {"ID",-36} {"Name",-20} {"EntityType",-15} {"EntityId",-36}");
            Console.WriteLine(new string('-', 115));

            var entityFiles = db.EntityFiles.ToList();
            var models = db.Modules.ToList();
            var lessons = db.EducationLessons.ToList();
            var programs = db.Programs.ToList();
            var subdivisions = db.Subdivisions.ToList();
            var summaries = db.Summaries.ToList();
            var competence = db.Competences.ToList();
            var competencyElements = db.CompetencyElements.ToList();
            var groupsOfCompetences = db.GroupOfCompetences.ToList();
            var speсialties = db.Speсialty.ToList();
            var profiles = db.Profiles.ToList();
            var professions = db.Professions.ToList();
            var organizations = db.Organizations.ToList();
            var equipments = db.Equipments.ToList();
            var employees = db.Employees.ToList();
            var compartments = db.Compartments.ToList();

            var orphanedFiles = new List<EntityFile>();
            foreach( var file in entityFiles)
            {
                if(file.EntityType == "Lesson" || file.EntityType == "Урок")
                {
                    if (!lessons.Any(l => l.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                } 
                else if(file.EntityType == "Module" || file.EntityType == "Модуль")
                {
                    if (!models.Any(m => m.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                } 
                else if(file.EntityType == "Образовательная программа")
                {
                    if (!programs.Any(p => p.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Подразделение")
                {
                    if (!subdivisions.Any(s => s.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Summary")
                {
                    if (!summaries.Any(s => s.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Компетенция")
                {
                    if (!competence.Any(c => c.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Элемент компетенции")
                {
                    if (!competencyElements.Any(c => c.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Группа компетений")
                {
                    if (!groupsOfCompetences.Any(g => g.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Специальность")
                {
                    if (!speсialties.Any(s => s.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Профиль")
                {
                    if (!profiles.Any(p => p.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Профессия")
                {
                    if (!professions.Any(p => p.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Организация")
                {
                    if (!organizations.Any(o => o.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Материальный ресурс")
                {
                    if (!equipments.Any(e => e.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Кадровый ресурс")
                {
                    if (!employees.Any(e => e.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
                else if(file.EntityType == "Помещение")
                {
                    if (!compartments.Any(c => c.Id.ToString() == file.EntityId))
                    {
                        orphanedFiles.Add(file);
                    }
                }
            }


            int i = 1;
            foreach (var u in orphanedFiles)
            {
                Console.WriteLine($"{i++,-4} {u.Id,-20} {u.Name,-20} {u.EntityType,-15} {u.EntityId,-36}");
            }
            Console.WriteLine();
        }
    }
}
