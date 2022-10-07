using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartupLib.Models;
using System.Data.Entity;
using System.Text.Json;

namespace Startup.Controllers
{
    [ApiController]
    public abstract class BaseController<Entity> : ControllerBase where Entity : Base
    {
        protected SchoolDbContext _context;

        public BaseController(SchoolDbContext context)
        {
            _context = context;
        }

        protected abstract DbSet<Entity> Set { get; }

        [HttpGet]
        public ActionResult<List<Entity>> Get() => Set.ToList();

        [HttpGet("{id}")]
        public Entity? Get(int id) => Set.Find(id);

        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            //if (!ModelState.IsValid) return BadRequest($"Invalid model state: {ModelState}");

            Entity? school = JsonSerializer.Deserialize<Entity>(value);

            if (school is null) return BadRequest($"Invalid json received: {value}");

            Set.Add(school);
            _context.SaveChangesAsync();

            return Created($"api/schools/{school.Id}", school);
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string value)
        {
            Entity? school = JsonSerializer.Deserialize<Entity>(value);

            if (school is null) return BadRequest($"Invalid json received: {value}");

            School? schoolToUpdate = _context.Schools.Find(id);

            if (schoolToUpdate is null) return NotFound($"School with id {id} not found");

            _context.Entry(schoolToUpdate).CurrentValues.SetValues(school);
            _context.SaveChangesAsync();

            return Ok($"School with id {id} updated");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Entity? school = Set.Find(id);

            if (school is null) return NotFound($"School with id {id} not found");

            Set.Remove(school);
            _context.SaveChangesAsync();

            return Ok($"School with id {id} deleted");
        }



    }
}
