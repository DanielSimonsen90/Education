using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Database;
using SmartWeightLib.Models;
using System.Timers;

namespace SmartWeightAPI.Controllers
{
    [Route("api/measurements/partials")]
    public class PartialMeasurementsController : BaseModelController<PartialMeasurement>
    {
        private static readonly int MEASUREMENTS_TIME_MS = 1000 * 60 * 10; // Every 10 minutes
        public PartialMeasurementsController(SmartWeightDbContext context) : base(context) 
        {
            var timer = new System.Timers.Timer(MEASUREMENTS_TIME_MS);
            timer.Elapsed += OnIdleTick;
            timer.Start();
        }

        private void OnIdleTick(object? state, ElapsedEventArgs args)
        {
            // No partial measurements
            if (GetEntities().Count == 0) return;

            // Select partial entries that are 10+ minutes old
            List<Measurement> partials = _context.Measurements
                .Where(m => m.Date < DateTime.Now.AddMilliseconds(MEASUREMENTS_TIME_MS))
                .ToList();

            // Partials saved are less than 10 minutes old, and therefore don't need to be removed just yet
            if (partials.Count == 0) return;

            // Remove all partials, that exceed limit
            _context.Measurements.RemoveRange(partials);
            _context.SaveChangesAsync();
        }
        
        protected override void AddEntity(PartialMeasurement entity) => _context.Measurements.Add(new Measurement(entity, null));
        protected override List<PartialMeasurement> GetEntities() => _context.Measurements
            .Where(m => m.UserId == null)
            .ToList<PartialMeasurement>();
        protected override PartialMeasurement? GetEntity(int id) => _context.Measurements.Find(id);
        protected override void DeleteEntity(PartialMeasurement entity) => _context.Measurements.Remove(_context.Measurements.Find(entity.Id));

        public override IActionResult Create([FromBody] PartialMeasurement entity)
        {
            // Use base create method. If it fails, return error
            IActionResult result = base.Create(entity);

            return result is OkObjectResult ?
                HandleMeasurement(entity.WeightId, MeasurementPartialTypes.PARTIAL_MEASUREMENT, result) :
                result;
        }
    }
}
