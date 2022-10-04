using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupLib.Models
{
    public abstract class Person : Base
    {
        public int SchoolId { get; set; } = -1;
        public School? School { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;

        public Person() {}
        public Person(string name, School school, DateTime? startTime = default)
        {
            Name = name;
            
            School = school;
            SchoolId = school.Id;
            StartTime = startTime ?? DateTime.Now;
        }
    }
}
