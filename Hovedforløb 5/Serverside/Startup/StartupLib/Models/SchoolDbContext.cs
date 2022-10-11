using StartupLib.Models.People;
using StartupLib.Models.People.Students;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
#nullable disable 

namespace StartupLib.Models
{
    public class SchoolDbContext : DbContext
    {

        public SchoolDbContext() : 
#if true
            base("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=H5_School;Trusted_Connection=true")
#else
#endif
        {

        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Student> Students { get; set; }
        public DbSet<ITStudent> ITStudents { get; set; }
        public DbSet<ProgStudent> ProgStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // School
            builder.Entity<School>()
                .HasKey(s => s.Id)
                .HasMany(s => s.People)
                .WithRequired(s => s.School)
                .HasForeignKey(s => s.SchoolId);
            builder.Entity<School>()
                .HasMany(s => s.Students)
                .WithRequired(s => s.School)
                .HasForeignKey(s => s.SchoolId);
            builder.Entity<School>()
                .HasMany(s => s.Employees)
                .WithRequired(e => e.School)
                .HasForeignKey(s => s.SchoolId);

            // Subject
            builder.Entity<Subject>()
                .HasKey(s => s.Id)
                .HasRequired(s => s.School);
            builder.Entity<Subject>()
                .HasRequired(s => s.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(s => s.TeacherId);
            builder.Entity<Subject>()
                .HasMany(s => s.Students)
                .WithMany(s => s.Subjects);

            // Employee
            builder.Entity<Employee>()
                .HasOptional(e => e.Boss);

            // Student
            builder.Entity<Student>()
                .HasRequired(s => s.MainTeacher)
                .WithMany(t => t.Students)
                .HasForeignKey(s => s.MainTeacherId);

            // Person
            builder.Entity<Person>()
                .HasKey(p => p.Id)
                .HasRequired(p => p.School)
                .WithMany(s => s.People)
                .HasForeignKey(p => p.SchoolId);
            //builder.Entity<Person>()
            //    .HasMany(p => p.Subjects)
            //    .WithMany(s => s.Students);
            builder.Entity<Person>()
                .HasMany(p => p.Subjects)
                .WithRequired(s => s.Teacher)
                .HasForeignKey(p => p.TeacherId);
        }
    }
}
