using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupLib.Models.People
{
    public class Employee : Person
    {
        public int BossId { get; set; } = -1;
        public Employee? Boss { get; set; }

        public Employee(string name, School school, DateTime startTime, Employee boss) : 
            base(name, school, startTime)
        {
            Boss = boss;
            BossId = boss.Id;
        }
    }
}
