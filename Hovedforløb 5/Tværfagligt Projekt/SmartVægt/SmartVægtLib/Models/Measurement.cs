namespace SmartWeightLib.Models
{
    public class Measurement : PartialMeasurement, IDbItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public Measurement(int userId, double weight, DateTime? date) : 
            base(weight, date)
        {
            UserId = userId;
        }
    }
}
