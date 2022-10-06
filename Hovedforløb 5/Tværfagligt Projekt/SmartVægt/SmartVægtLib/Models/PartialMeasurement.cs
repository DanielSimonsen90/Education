namespace SmartWeightLib.Models
{
    public class PartialMeasurement
    {
        public double Weight { get; set; }
        public DateTime Date { get; set; }

        public PartialMeasurement() { }
        public PartialMeasurement(double weight, DateTime? date)
        {
            Weight = weight;
            Date = date ?? DateTime.Now;
        }
    }
}
