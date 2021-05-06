using NGC_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGC_Razor.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            if (context.Students.Any())
                return;

            var enrollementDate = DateTime.Parse("2021-04-06");
            context.Students.AddRange(
                new Student { FirstMidName = "Daniel Danho", LastName = "Simonsen", EnrollmentDate = enrollementDate },
                new Student { FirstMidName = "Synthy", LastName = "Sytro", EnrollmentDate = enrollementDate },
                new Student { FirstMidName = "Moana", LastName = "Motunui", EnrollmentDate = enrollementDate }
            );
            context.SaveChanges();

            context.Courses.AddRange(
                new Course { CourseID = 1000, Title = "GUI", Credits = 3 },
                new Course { CourseID = 1001, Title = "Database", Credits = 4 },
                new Course { CourseID = 1002, Title = "Clientside", Credits = 3 },
                new Course { CourseID = 1003, Title = "Serverside", Credits = 3 },
                new Course { CourseID = 1004, Title = "Embedded", Credits = 4 }
            );
            context.SaveChanges();

            context.Enrollments.AddRange(
                new Enrollment { StudentID = 1, CourseID = 1000, Grade = Grade.TWELVE }, //Daniel GUI
                new Enrollment { StudentID = 1, CourseID = 1001, Grade = Grade.SEVEN }, //Daniel Database
                new Enrollment { StudentID = 2, CourseID = 1002, Grade = Grade.TEN }, //Synthy Clientside
                new Enrollment { StudentID = 2, CourseID = 1003, Grade = Grade.SEVEN }, //Synthy Serverside
                new Enrollment { StudentID = 3, CourseID = 1004, Grade = Grade.ZERO }, //Moana Embedded
                new Enrollment { StudentID = 3, CourseID = 1000, Grade = Grade.TWO } //Moana GUI
            );
            context.SaveChanges();
        }
    }
}
