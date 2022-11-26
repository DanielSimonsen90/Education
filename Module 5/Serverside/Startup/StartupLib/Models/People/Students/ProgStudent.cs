using System.ComponentModel.DataAnnotations.Schema;

namespace StartupLib.Models.People.Students
{
    [Table("Prog_Student")]
    public class ProgStudent : Student
    {
        public ProgStudent(string name, School school, DateTime startTime, Employee mainTeacher) : 
            base(name, school, startTime, mainTeacher)
        {
        }

        public string? Github { get; set; }
    }
}
