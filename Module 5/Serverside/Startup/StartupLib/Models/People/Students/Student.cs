using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupLib.Models.People.Students
{
    public abstract class Student : Person
    {
        [Required]
        [ForeignKey("MainTeacherId")]
        public Employee MainTeacher { get; set; }
        public int MainTeacherId { get; set; }

        public Student(string name, School school, DateTime startTime, Employee mainTeacher) :
            base(name, school, startTime)
        {
            MainTeacher = mainTeacher;
            MainTeacherId = mainTeacher.Id;
        }
    }
}
