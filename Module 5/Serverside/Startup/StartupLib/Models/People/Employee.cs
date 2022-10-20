using StartupLib.Models.People.Students;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupLib.Models.People
{
    [Table("Employee")]
    public class Employee : Person
    {
        [Required]
        [ForeignKey("BossId")]
        public Employee? Boss { get; set; }
        public int BossId { get; set; }

        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public Employee() {}
        public Employee(string name, School school, DateTime startTime, Employee boss, params Student[] students) : 
            base(name, school, startTime)
        {
            Boss = boss;
            BossId = boss.Id;
            Students = students;
        }
    }
}
