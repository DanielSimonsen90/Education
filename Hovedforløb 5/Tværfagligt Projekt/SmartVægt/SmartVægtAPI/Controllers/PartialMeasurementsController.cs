using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Database;
using SmartWeightLib.Models;
using System.Net;
using System.Text.Json;

namespace SmartWeightAPI.Controllers
{
    [Route("api/measurements/partial")]
    public class PartialMeasurementsController : BaseModelController<PartialMeasurement>
    {
        private static readonly int MEASUREMENTS_TIME_MS = 1000 * 60 * 10; // Every 10 minutes
        public PartialMeasurementsController(SmartWeightDbContext context) : base(context) 
        {
            var timer = new System.Timers.Timer(MEASUREMENTS_TIME_MS);
            timer.Elapsed += (state, args) =>
            {
                // No partial measurements
                if (_context.PartialMeasurements.ToList().Count == 0) return;

                // Select partial entries that are 10+ minutes old
                List<PartialMeasurement> partials = _context.PartialMeasurements
                    .Where(p => p.Date < DateTime.Now.AddMilliseconds(-MEASUREMENTS_TIME_MS))
                    .ToList();
                
                // Partials saved are less than 10 minutes old, and therefore don't need to be removed just yet
                if (partials.Count == 0) return;

                // Remove all partials, that exceed limit
                _context.PartialMeasurements.RemoveRange(partials);
                _context.SaveChangesAsync();
            };
            timer.Start();
        }

        protected override void AddEntity(PartialMeasurement entity) => _context.PartialMeasurements.Add(entity);

        protected override List<PartialMeasurement> GetEntities() => _context.PartialMeasurements.ToList();

        protected override PartialMeasurement? GetEntity(int id) => _context.PartialMeasurements.First(m => m.Id == id);
        protected override void DeleteEntity(PartialMeasurement entity) => _context.PartialMeasurements.Remove(entity);

        public override IActionResult Create([FromBody] PartialMeasurement entity)
        {
            // Use base create method. If it fails, return error
            IActionResult result = base.Create(entity);
            if (result is not OkObjectResult) return result;

            return HandleMeasurement(entity.Id, MeasurementPartialTypes.PARTIAL_MEASUREMENT, result);
        }
    }
}
