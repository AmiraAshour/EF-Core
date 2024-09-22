using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigration.Entity
{
    public class Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; }

        //Requerd
        public int CourseId { get; set; }
        public Course Course { get;set; }

        //optional
        public int? InstructorId {  get; set; }
        public Instructor? Instructor { get; set; }

        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();


    }
}
