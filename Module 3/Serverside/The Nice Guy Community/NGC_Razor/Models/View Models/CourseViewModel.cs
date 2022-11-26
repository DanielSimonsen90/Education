using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortosoUniversity.Models.View_Models
{
    public class CourseViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string Department { get; set; }
    }
}
