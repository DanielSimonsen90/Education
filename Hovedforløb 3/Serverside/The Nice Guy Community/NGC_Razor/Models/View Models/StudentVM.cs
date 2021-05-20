using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortosoUniversity.Models.View_Models
{
    public class StudentVM
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
