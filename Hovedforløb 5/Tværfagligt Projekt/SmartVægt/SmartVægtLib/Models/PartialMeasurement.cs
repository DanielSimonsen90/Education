namespace SmartWeightLib.Models
{
    public class PartialMeasurement : IDbItem
    {
        public int Id { get; set; }
        public int WeightId { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }

        public PartialMeasurement() { }
        public PartialMeasurement(int weightId, double weight, DateTime? date)
        {
            WeightId = weightId;
            Weight = weight;
            Date = date ?? DateTime.Now;
        }
    }
}
