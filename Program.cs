using CodeFirstMigration.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {

                var sections = context.Sections
                    .Include(x => x.Course)
                    .Include(x => x.Instructor)
                    .Include(x => x.Schedules)
                    .Include(x => x.SectionSchedules);

                Console.WriteLine("| Id |  Course      | Section | Instructor           | Schedule       | Time Slot     | SUN | MON | TUE | WED | THU | FRI | SAT |");
                Console.WriteLine("|----|--------------|---------|----------------------|----------------|---------------|-----|-----|-----|-----|-----|-----|-----|");

                foreach (var section in sections)
                {
                    string sunday = section.Schedules.Any(x=>x.SUN) ? " x" : "";
                    string monday = section.Schedules.Any(x => x.MON) ? " x" : "";
                    string tuesday = section.Schedules.Any(x => x.TUE) ? " x" : "";
                    string wednesday = section.Schedules.Any(x => x.WED) ? " x" : "";
                    string thursday = section.Schedules.Any(x => x.THU )? " x" : "";
                    string friday = section.Schedules.Any(x => x.FRI )? " x" : "";
                    string saturday = section.Schedules.Any(x => x.SAT) ? " x" : "";

                    Console.WriteLine($"| {section.Id.ToString().PadLeft(2, '0')} | {section.Course.CourseName,-12} | {section.SectionName,-7} | {(section.Instructor?.FName + " " + section.Instructor?.LName),-20} | {section.Schedules.FirstOrDefault()?.Title,-14} | {section.SectionSchedules.FirstOrDefault()?.StartTime.ToString("hh\\:mm"),-5} - {section.SectionSchedules.FirstOrDefault() ? .EndTime.ToString("hh\\:mm"),-5} | {sunday,-3} | {monday,-3} | {tuesday,-3} | {wednesday,-3} | {thursday,-3} | {friday,-3} | {saturday,-3} |");
                }
            }


        }
    }
}
