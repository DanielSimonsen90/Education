using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Database;
using SmartWeightLib.Models;
using System.Data;
using System.Data.Entity.Validation;

namespace SmartWeightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseModelController<User>
    {
        public UsersController(SmartWeightDbContext context) : base(context)
        {

        }

        protected override void AddEntity(User entity) => _context.Users.Add(entity);
        protected override List<User> GetEntities() => _context.Users.ToList();
        protected override User? GetEntity(int id) => _context.Users.First(u => u.Id == id);
        protected override void DeleteEntity(User entity) => _context.Users.Remove(entity);
    }
}
