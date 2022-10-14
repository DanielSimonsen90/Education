using Microsoft.AspNetCore.Mvc;
using SmartWeightAPI.Controllers.Base;
using SmartWeightLib.Database;
using SmartWeightLib.Models;

namespace SmartWeightAPI.Controllers
{
    [Route("api/users")]
    public class UsersController : BaseModelController<User>
    {
        public UsersController(SmartWeightDbContext context) : base(context)
        {

        }

        protected override void AddEntity(User entity) => _context.Users.Add(entity);
        protected override List<User> GetEntities() => _context.Users.ToList();
        protected override User? GetEntity(int id) => _context.Users.Find(id);
        protected override void DeleteEntity(User entity) => _context.Users.Remove(entity);
    }
}
