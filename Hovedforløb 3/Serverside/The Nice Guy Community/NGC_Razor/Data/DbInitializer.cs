using CortosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortosoUniversity.Data
{
    public class DbInitializer
    {
        private readonly SchoolContext _context;

        public DbInitializer(SchoolContext context)
        {
            this._context = context;
        }

        public void Initialize()
        {
            if (_context.Students.Any()) return;

            var enrollementDate = DateTime.Parse("2021-04-06");
            var students = Initialize<Student>(c => c.Students, new Student[]
            {
                new Student { FirstMidName = "Daniel Danho", LastName = "Simonsen", EnrollmentDate = enrollementDate },
                new Student { FirstMidName = "Synthy", LastName = "Sytro", EnrollmentDate = enrollementDate },
                new Student { FirstMidName = "Moana", LastName = "Motunui", EnrollmentDate = enrollementDate }
            }, s => s.FirstMidName);
            
            var instructors = Initialize<Instructor>(c => c.Instructors, new Instructor[]
            {
                new Instructor() { FirstMidName = "Simon Hoxer", LastName = "Brønding", HireDate = DateTime.Parse("2020-10-4") },
                new Instructor() { FirstMidName = "Frank", LastName = "Rosbak", HireDate = DateTime.Parse("1990-1-23") },
                new Instructor() { FirstMidName = "Lars Thise", LastName = "Pedersen", HireDate = DateTime.Parse("2000-08-16") },
                new Instructor() { FirstMidName = "Henrik", LastName = "Kramer", HireDate = DateTime.Parse("1995-4-1") },
                new Instructor() { FirstMidName = "Lærke Brandhøj", LastName = "Kristensen", HireDate = DateTime.Parse("2020-10-4") },
                new Instructor() { FirstMidName = "Kim", LastName = "Kaurin", HireDate = DateTime.Parse("2010-6-27") }
            }, i => i.FirstMidName);
            var officeAssignments = Initialize<OfficeAssignment>(c => c.OfficeAssignments, new OfficeAssignment[]
            {
                new OfficeAssignment() { Instructor = _context.Instructors.ToList().Find(i => i.ID == 1), Location = "C212" },
                new OfficeAssignment() { Instructor = _context.Instructors.ToList().Find(i => i.ID == 2), Location = "D225" },
                new OfficeAssignment() { Instructor = _context.Instructors.ToList().Find(i => i.ID == 3), Location = "C115" },
                new OfficeAssignment() { Instructor = _context.Instructors.ToList().Find(i => i.ID == 4), Location = "D225" },
            }, oa => oa.Location);
            
            var startDate = DateTime.Parse("2021-8-8");
            var dataDepartment = new Department()
            {
                Name = "Data",
                Budget = 0,
                StartDate = startDate,
                Administrator = _context.Instructors.ToList().Find(i => i.FirstMidName == "Lars Thise")
            };
            
            var departments = Initialize<Department>(c => c.Departments, new Department[]
            {
                dataDepartment,
                new Department()
                {
                    Name = "Digital Media",
                    Budget = 10000,
                    StartDate = startDate,
                    Administrator = _context.Instructors.ToList().Find(i => i.FirstMidName == "Kim")
                }
            }, d => d.Name);
            var courses = Initialize<Course>(c => c.Courses, new Course[]
            {
                new Course { ID = 1000, Title = "GUI", Credits = 3, Department = dataDepartment },
                new Course { ID = 1001, Title = "Database", Credits = 4, Department = dataDepartment },
                new Course { ID = 1002, Title = "Clientside", Credits = 3, Department = dataDepartment },
                new Course { ID = 1003, Title = "Serverside", Credits = 3, Department = dataDepartment },
                new Course { ID = 1004, Title = "Embedded", Credits = 4, Department = dataDepartment },
                new Course { ID = 1005, Title = "Animation", Credits = 2, Department = _context.Departments.ToList().Find(d => d.Name == "Digital Media") }
            }, c => c.ID.ToString());
            
            Initialize<Enrollment>(c => c.Enrollments, new Enrollment[]
            {
                new Enrollment { StudentID = 1, CourseID = 1000, Grade = Grade.TWELVE }, //Daniel GUI
                new Enrollment { StudentID = 1, CourseID = 1001, Grade = Grade.SEVEN }, //Daniel Database
                new Enrollment { StudentID = 2, CourseID = 1002, Grade = Grade.TEN }, //Synthy Clientside
                new Enrollment { StudentID = 2, CourseID = 1003, Grade = Grade.SEVEN }, //Synthy Serverside
                new Enrollment { StudentID = 3, CourseID = 1004, Grade = Grade.ZERO }, //Moana Embedded
                new Enrollment { StudentID = 3, CourseID = 1000, Grade = Grade.TWO } //Moana GUI
            });
        }

        private Dictionary<string, T> Initialize<T>(Func<SchoolContext, DbSet<T>> dbSetCallback, T[] entries, Func<T, string> keyCallback = null) where T : class
        {
            Dictionary<string, T> result = new();
            if (keyCallback != null)
                entries.ToList().ForEach(e => result.Add(keyCallback(e), e));

            dbSetCallback(_context).AddRange(entries);
            _context.SaveChanges();

            return result;
        }
    }
}
