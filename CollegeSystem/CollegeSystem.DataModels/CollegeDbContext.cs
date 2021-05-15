using CollegeSystem.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeSystem.DataModels
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions options)
             : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .ToTable("Students")
                .HasKey(k => k.StudentNumberID);

            modelBuilder
                .Entity<Student>()
                .Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder
                .Entity<Student>()
                .Property(p => p.MobilePhone)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder
                .Entity<Student>()
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder
                .Entity<Subject>()
                .ToTable("Subjects")
                .HasKey(k => k.SubjectID);

            modelBuilder
                .Entity<Subject>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder
                .Entity<Subject>()
                .Property(p => p.Semester)
                .IsRequired();

            modelBuilder
                .Entity<Subject>()
                .Property(p => p.Credits)
                .IsRequired();

            modelBuilder
                .Entity<Student>()
                .HasMany(sb => sb.Subjects)
                .WithMany(s => s.Students);

            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {         
            // subjects
            var mathematics = new Subject()
            {
                SubjectID = 1,
                Name = "Mathematics",
                Credits = 3,
                Semester = 1,
            };

            var english = new Subject()
            {
                SubjectID = 2,
                Name = "English",
                Credits = 5,
                Semester = 2
            };

            var programing = new Subject()
            {
                SubjectID = 3,
                Name = "Programming and Advanced Programming",
                Credits = 10,
                Semester = 2,
            };

            modelBuilder
               .Entity<Subject>()
               .HasData(mathematics, english, programing);

            // students
            var student1 = new Student()
            {
                StudentNumberID = 1,
                FullName = "Bob Bobsky",
                Email = "bob.bobsky@gmail.com",
                MobilePhone = "38971634256",
            };
            var student2 = new Student()
            {
                StudentNumberID = 2,
                FullName = "Jill Wayne",
                Email = "jill.wayne@gmail.com",
                MobilePhone = "38971567489",
            };
                                 
            modelBuilder
                .Entity<Student>()
                .HasData(student1, student2);
                       
        }
    }
}
