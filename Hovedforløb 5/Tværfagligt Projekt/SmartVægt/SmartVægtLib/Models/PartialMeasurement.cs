using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace SmartWeightLib.Models
{
    /// <summary>
    /// A partial measurement sent by the weight, when it has been used.
    /// </summary>
    public class PartialMeasurement : IDbItem
    {
        public int Id { get; set; }
        public int WeightId { get; set; }
        [ForeignKey("WeightId")]
        public Weight Weight { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public PartialMeasurement() { }
        public PartialMeasurement(Weight weight, double value, DateTime? date)
        {
            Weight = weight;
            WeightId = weight.Id;
            Value = value;
            Date = date ?? DateTime.Now;
        }
    }
}
