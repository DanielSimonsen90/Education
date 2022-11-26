using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CortosoUniversity.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstMidName} {LastName}";
    }
}
