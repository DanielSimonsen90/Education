using System.ComponentModel.DataAnnotations;

namespace NGC_Razor.Models
{
    public enum Grade { TWELVE, TEN, SEVEN, FOUR, TWO, ZERO, NEGATIVE_THREE }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}