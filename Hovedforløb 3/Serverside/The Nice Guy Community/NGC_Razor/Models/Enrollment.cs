using System.ComponentModel.DataAnnotations;

namespace CortosoUniversity.Models
{
    public enum Grade { TWELVE, TEN, SEVEN, FOUR, TWO, ZERO, NEGATIVE_THREE }

    public class Enrollment
    {
        public int ID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}