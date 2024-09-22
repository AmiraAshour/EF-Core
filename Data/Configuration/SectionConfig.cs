using CodeFirstMigration.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigration.Data.Configuration
{
    internal class SectionConfig : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);//primary key
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.SectionName).//varchar(250) not null
                HasColumnType("VARCHAR")
                .HasMaxLength(250)
                .IsRequired();
            
            // one to many
            builder.HasOne(x => x.Course)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseId)
                .IsRequired();

            builder.HasOne(x => x.Instructor)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.InstructorId)
                .IsRequired(false);

            // many to many 
            builder.HasMany(x => x.Schedules)
                .WithMany(x => x.Sections)
                .UsingEntity<SectionSchedule>();

              builder.HasMany(x => x.Students)
                .WithMany(x => x.Sections)
                .UsingEntity<Enrollment>();

            builder.ToTable("Sections");

            builder.HasData(LoadSections());// insert data in table 
        }
        private static List<Section> LoadSections()
        {
            return new List<Section>
            {
                new Section { Id = 1, SectionName = "S_MA1", CourseId = 1, InstructorId = 1},
                new Section { Id = 2, SectionName = "S_MA2", CourseId = 1, InstructorId = 2},
                new Section { Id = 3, SectionName = "S_PH1", CourseId = 2, InstructorId = 1},
                new Section { Id = 4, SectionName = "S_PH2", CourseId = 2, InstructorId = 3},
                new Section { Id = 5, SectionName = "S_CH1", CourseId = 3, InstructorId =2},
                new Section { Id = 6, SectionName = "S_CH2", CourseId = 3, InstructorId = 3},
                new Section { Id = 7, SectionName = "S_BI1", CourseId = 4, InstructorId = 4},
                new Section { Id = 8, SectionName = "S_BI2", CourseId = 4, InstructorId = 5},
                new Section { Id = 9, SectionName = "S_CS1", CourseId = 5, InstructorId = 4},
                new Section { Id = 10, SectionName = "S_CS2", CourseId = 5, InstructorId = 5},
                new Section { Id = 11, SectionName = "S_CS3", CourseId = 5, InstructorId = 4}
            };
        }
    }
}
