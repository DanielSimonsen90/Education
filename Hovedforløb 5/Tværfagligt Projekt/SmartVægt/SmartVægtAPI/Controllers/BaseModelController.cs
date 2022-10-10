using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Database;
using SmartWeightLib.Models;
using System.Net;

namespace SmartWeightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract partial class BaseModelController<Entity> : ControllerBase where Entity : IDbItem
    {
        protected readonly SmartWeightDbContext _context;
        public BaseModelController(SmartWeightDbContext context)
        {
            _context = context;
        }

        protected abstract void AddEntity(Entity entity);
        protected abstract Entity? GetEntity(int id);
        protected abstract List<Entity> GetEntities();
        protected abstract void DeleteEntity(Entity entity);

        [HttpPost]
        public virtual IActionResult Create([FromBody] Entity entity)
        {
            if (!ModelState.IsValid) return BadRequest("Provided entity is invalid.");

            AddEntity(entity);
            _context.SaveChanges();
            
            return Ok(entity);
        }

        [HttpGet]
        public virtual IActionResult GetAll(bool fromPostman = false)
        {
            if (!fromPostman) return Unauthorized();
            return Ok(GetEntities());
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetOne(int id)
        {
            Entity? entity = GetEntity(id);

            return entity == null ? 
                NotFound($"No entity found with id {id}") :
                Ok(entity);
        }


        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, [FromBody] Entity entity)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid model state");

            Entity? oldEntity = GetEntity(id);

            if (oldEntity == null) return NotFound("No entity with that id");

            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            Entity? entity = GetEntity(id);

            if (entity == null) return NotFound("No entity with that id");

            DeleteEntity(entity);
            _context.SaveChanges();

            return Ok();
        }

        // TODO: Move to helper class or something similar, so ConnectionsController can use
        /// <summary>
        /// Checks if there's a connection between any ids, and if so, add the measurement to the database
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <param name="type">user | weight</param>
        protected IActionResult HandleMeasurement(int id, MeasurementPartialTypes type, IActionResult result)
        {
            // Is weight connected to a user, if not, then maybe user connects after weight was used
            Connection? conn =
                type == MeasurementPartialTypes.USER ? _context.Connections.First(c => c.UserId == id) :
                type == MeasurementPartialTypes.PARTIAL_MEASUREMENT ? _context.Connections.First(c => c.WeightId == id) :
                null;
            if (conn is null) return result;

            // Get partial measurement, if any
            PartialMeasurement? partialMeasurement = _context.PartialMeasurements.First(p => p.WeightId == conn.WeightId);
            if (partialMeasurement is null) return result;

            // Delete connection regardless of what happens next
            var client = new HttpClient();
            client.DeleteAsync($"{_endpoints[Endpoints.CONNECTIONS]}/{conn.Id}");

            // Get user from connection
            User user = _context.Users.First(u => u.Id == conn.UserId);
            if (user is null) return StatusCode(StatusCodes.Status500InternalServerError, "User not found - connection is corrupted");

            // Save measurement
            var measurement = new Measurement(
                conn.UserId, 
                partialMeasurement.WeightId, 
                partialMeasurement.Weight, 
                partialMeasurement.Date);
            HttpResponseMessage? posted = client.PostAsync($"{_endpoints[Endpoints.MEASUREMENTS]}", new JsonContent(measurement)).Result;

            // Delete partial measurement
            client.DeleteAsync($"{_endpoints[Endpoints.PARTIAL_MEASUREMENTS]}/{partialMeasurement.Id}");

            return posted.StatusCode == HttpStatusCode.OK ?
                Ok("Measurement saved.") :
                StatusCode(StatusCodes.Status500InternalServerError, "Failed to save measurement.");
        }
    }

    public enum MeasurementPartialTypes 
    { 
        USER,
        PARTIAL_MEASUREMENT
    }
}
