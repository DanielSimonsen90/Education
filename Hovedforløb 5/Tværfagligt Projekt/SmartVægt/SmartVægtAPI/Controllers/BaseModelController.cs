using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Database;
using SmartWeightLib.Models;
using System.Data.Entity;

namespace SmartWeightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseModelController<Entity> : Controller where Entity : IDbItem
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

        public virtual IActionResult Create(Entity entity)
        {
            if (!ModelState.IsValid) return BadRequest("Provided entity is invalid.");

            AddEntity(entity);
            _context.SaveChanges();
            
            return Ok(entity);
        }

        // GET /users
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
    }
}
