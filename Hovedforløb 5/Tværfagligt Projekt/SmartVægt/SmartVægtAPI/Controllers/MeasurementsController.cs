using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Database;
using SmartWeightLib.Models;

namespace SmartWeightAPI.Controllers
{
    [Route("api/measurements")]
    public class MeasurementsController : BaseModelController<Measurement>
    {
        public MeasurementsController(SmartWeightDbContext context) : base(context)
        {
            
        }

        // GET /measurements/overview/1
        [HttpGet("overview/{userId}")]
        public IActionResult Overview(int userId)
        {
            List<Measurement>? measurements = _context.Measurements
                .Where(m => m.UserId == userId)
                .OrderBy(m => m.Date)
                .ToList();

            return measurements is null || measurements.Count == 0 ?
                NotFound($"No measurements found for user {userId}") :
                Ok(measurements);
        }

        protected override void AddEntity(Measurement entity) => _context.Measurements.Add(entity);
        protected override List<Measurement> GetEntities() => _context.Measurements.ToList();
        protected override Measurement? GetEntity(int id) => _context.Measurements.Find(id);
        protected override void DeleteEntity(Measurement entity) => _context.Measurements.Remove(entity);

        [HttpGet("fitler")]
        public ActionResult<List<Measurement>> GetAll(MeasurementFilter filter = MeasurementFilter.ALL)
        {
            return Ok(GetEntities().Where(measurement => filter switch
            {
                MeasurementFilter.FULL => measurement.User is not null,
                MeasurementFilter.PARTIALS => measurement.User is null,
                _ => true
            }));
        }
    }
}
