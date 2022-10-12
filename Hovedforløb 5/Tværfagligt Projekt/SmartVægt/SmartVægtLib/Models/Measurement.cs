using System.ComponentModel.DataAnnotations.Schema;

namespace SmartWeightLib.Models
{
    /// <summary>
    /// Full measurement
    /// </summary>
    public class Measurement : PartialMeasurement
    {
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public Measurement(User user, Weight weight, double value, DateTime? date) : 
            base(weight, value, date)
        {
            User = user;
            UserId = user.Id;
        }
        public Measurement(PartialMeasurement partial, User? user) : 
            base(partial.Weight, partial.Value, partial.Date) 
        {
            User = user;
            UserId = user?.Id;
        }
    }
}
