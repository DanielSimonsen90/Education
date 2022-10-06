using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using SmartWeightLib.Database;
using SmartWeightLib.Models;

namespace SmartWeightAPI.Controllers
{
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

        protected override Measurement? GetEntity(int id) => _context.Measurements.First(m => m.Id == id);

        protected override void DeleteEntity(Measurement entity) => _context.Measurements.Remove(entity);

    }
}
