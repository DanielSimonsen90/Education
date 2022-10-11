using StartupLib.Models.People;
using StartupLib.Models.People.Students;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupLib.Models
{
    [Table("Subjects")]
    public class Subject : Base
    {
        [Required]
        [ForeignKey("SchoolId")]
        public School? School { get; set; }
        public int SchoolId { get; set; } = -1;

        [Required]
        [ForeignKey("TeacherId")]
        public Employee? Teacher { get; set; }
        public int TeacherId { get; set; } = -1;

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
