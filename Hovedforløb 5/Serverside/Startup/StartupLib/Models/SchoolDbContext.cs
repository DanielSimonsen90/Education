using StartupLib.Models.People;
using StartupLib.Models.People.Students;
using System.Data.Entity;
#nullable disable 

namespace StartupLib.Models
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Student> Students { get; set; }
        public DbSet<ITStudent> ITStudents { get; set; }
        public DbSet<ProgStudent> ProgStudents { get; set; }
    }
}
