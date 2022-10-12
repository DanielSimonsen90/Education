using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Database;
using SmartWeightLib.Models;

namespace SmartWeightAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public abstract class BaseModelController<Entity> : BaseController where Entity : IDbItem
    {
        protected BaseModelController(SmartWeightDbContext context) : base(context) {}

        protected abstract void AddEntity(Entity entity);
        protected abstract Entity? GetEntity(int id);
        protected abstract List<Entity> GetEntities();
        protected abstract void DeleteEntity(Entity entity);

        [HttpPost]
        public virtual IActionResult Create([FromBody] Entity entity)
        {
            if (!ModelState.IsValid) return BadRequest($"Provided entity {nameof(entity)} is invalid.");

            AddEntity(entity);
            _context.SaveChangesAsync();

            return Created($"{nameof(entity)} created", entity);
        }

        [HttpGet]
        public virtual ActionResult<List<Entity>> GetAll(bool fromSwagger = false)
        {
            return !fromSwagger ? 
                Unauthorized("You do not have permission to view this information.") : 
                Ok(GetEntities());
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetOne(int id)
        {
            Entity? entity = GetEntity(id);

            return entity is null ? 
                NotFound($"No entity found with id {id}") :
                Ok(entity);
        }


        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, [FromBody] Entity entity)
        {
            if (!ModelState.IsValid) return BadRequest($"Provided entity {nameof(entity)} is invalid.");

            Entity? oldEntity = GetEntity(id);

            if (oldEntity is null) return NotFound("No entity with that id");

            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return Ok("Entity updated.");
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            Entity? entity = GetEntity(id);

            if (entity is null) return NotFound("No entity with that id");

            DeleteEntity(entity);
            _context.SaveChanges();

            return Ok("Entity deleted.");
        }
    }
}
