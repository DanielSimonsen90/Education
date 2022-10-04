#nullable disable

namespace StartupLib.Models
{
    public class School : Base
    {
        public ICollection<Person> People { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public School() {}
        public School(string name, ICollection<Employee> employees, ICollection<Student> students)
        {
            Name = name;
            Employees = employees;
            Students = students;
        }
    }
}