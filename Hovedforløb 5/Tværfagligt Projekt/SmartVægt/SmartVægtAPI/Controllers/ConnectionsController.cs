using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SmartWeightLib.Database;
using SmartWeightLib.Models;

namespace SmartWeightAPI.Controllers
{
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class ConnectionsController : BaseController
    {
        public ConnectionsController(SmartWeightDbContext context) : base(context) {}

        [HttpPost("{weightId}")]
        public IActionResult Connect(int weightId, int userId)
        {
            // Arguments provided are existing entities
            bool weightExists = _context.Weights.Any(w => w.Id == weightId);
            bool userExists = _context.Users.Any(u => u.Id == userId);
            if (!weightExists || !userExists) return NotFound("One or more entities not found");

            // Get previous connections
            var userConnection = _context.Connections.First(c => c.UserId == userId);
            var weightConnection = _context.Connections.First(c => c.WeightId == weightId);

            // Connections exist between entities
            if (userConnection == weightConnection && userConnection is not null) return Ok("Connection was already established.");

            // Remove any previous connections, if any
            if (userConnection is not null) _context.Connections.Remove(userConnection);
            if (weightConnection is not null) _context.Connections.Remove(weightConnection);

            // Create connection and save
            var conn = new Connection(userId, weightId);
            _context.Connections.Add(conn);
            _context.SaveChangesAsync();

            CreatedResult result = Created("connections/userId/weightId", conn);
            return HandleMeasurement(userId, MeasurementPartialTypes.USER, result);
        }

        [HttpGet]
        public IActionResult GetConnection(int userId, bool fromApp)
        {
            if (!fromApp) return Forbid("You are not allowed to view this information.");

            Connection conn = _context.Connections.First(c => c.UserId == userId);
            if (conn is null) return NotFound("User is not connected to any weight.");

            return Ok(conn);
        }

        [HttpDelete]
        public IActionResult Disconnect(int userId, bool fromApp)
        {
            if (!fromApp) return Forbid("You are not allowed to delete this connection.");

            Connection conn = _context.Connections.First(c => c.UserId == userId);
            if (conn is null) return Ok("Connection already deleted");

            _context.Connections.Remove(conn);
            _context.SaveChangesAsync();
            return Ok("Connection deleted");
        }
    }
}
