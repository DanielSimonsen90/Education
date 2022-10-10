namespace SmartWeightLib.Models
{
    public class Measurement : PartialMeasurement
    {
        public int UserId { get; set; }

        public Measurement(int userId, int weightId, double weight, DateTime? date) : 
            base(weightId, weight, date)
        {
            UserId = userId;
        }
    }
}
