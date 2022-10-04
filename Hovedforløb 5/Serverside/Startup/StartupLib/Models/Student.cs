using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupLib.Models
{
    public class Student : Person
    {
        public int MainTeacherId { get; set; }
        public Employee MainTeacher { get; set; }

        public Student(string name, School school, DateTime startTime, Employee mainTeacher) : 
            base(name, school, startTime)
        {
            MainTeacher = mainTeacher;
            MainTeacherId = mainTeacher.Id;
        }
    }
}
