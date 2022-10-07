using StartupLib.Models.People;
using StartupLib.Models.People.Students;

namespace StartupLib.Models
{
    public class Subject : Base
    {
        public int SchoolId { get; set; } = -1;
        public School? School { get; set; }

        public int TeacherId { get; set; } = -1;
        public Employee? Teacher { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public Subject() { }
        public Subject(string name, School school, Employee teacher, params Student[] students)
        {
            Name = name;
            School = school;
            SchoolId = school.Id;
            Teacher = teacher;
            TeacherId = teacher.Id;
            Students = students;
        }
    }
}
