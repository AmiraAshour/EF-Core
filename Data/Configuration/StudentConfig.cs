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
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();


            builder.HasData(LoadStudents());

            builder.ToTable("Students");
        }
        private static List<Student> LoadStudents()
        {

            return new List<Student>
            {
                 new Student() { Id = 1, FName = "Fatima", LName = "Ali" },
                 new Student() { Id = 2, FName = "Noor" , LName = "Saleh" },
                 new Student() { Id = 3, FName = "Omar" , LName = "Youssef" },
                 new Student() { Id = 4, FName = "Huda" , LName = "Ahmed" },
                 new Student() { Id = 5, FName = "Amira" , LName = "Tariq" },
                 new Student() { Id = 6, FName = "Zainab" , LName = "Ismail" },
                 new Student() { Id = 7, FName = "Yousef" , LName = "Farid" },
                 new Student() { Id = 8, FName = "Layla" , LName = "Mustafa" },
                 new Student() { Id = 9, FName = "Mohammed" , LName = "Adel" },
                 new Student() { Id = 10, FName = "Samira" , LName = "Nabil" }
            };
        }

    }
}
