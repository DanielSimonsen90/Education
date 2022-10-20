using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Text.Json;

namespace Startup.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public abstract class BaseController<Entity> : ControllerBase where Entity : Base
    {
        protected SchoolDbContext _context;

        public BaseController(SchoolDbContext context)
        {
            _context = context;
        }

        protected abstract DbSet<Entity> Set { get; }

        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            //if (!ModelState.IsValid) return BadRequest($"Invalid model state: {ModelState}");

            Entity? entity = JsonSerializer.Deserialize<Entity>(value);

            if (entity is null) return BadRequest($"Invalid json received: {value}");

            Set.Add(entity);
            _context.SaveChangesAsync();

            return Created($"api/schools/{entity.Id}", entity);
        }

        [HttpGet]
        public ActionResult<List<Entity>> Get() => Set.ToList();

        [HttpGet("{id}")]
        public Entity? Get(int id) => Set.Find(id);

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string value)
        {
            Entity? entity = JsonSerializer.Deserialize<Entity>(value);

            if (entity is null) return BadRequest($"Invalid json received: {value}");

            Entity? update = Set.Find(id);

            if (update is null) return NotFound($"School with id {id} not found");

            _context.Entry(update).CurrentValues.SetValues(entity);
            _context.SaveChangesAsync();

            return Ok($"School with id {id} updated");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Entity? entity = Set.Find(id);

            if (entity is null) return NotFound($"School with id {id} not found");

            Set.Remove(entity);
            _context.SaveChangesAsync();

            return Ok($"School with id {id} deleted");
        }



    }
}
