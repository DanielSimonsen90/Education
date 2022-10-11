using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Startup.Controllers
{
    [Route("api/schools")]
    [ApiController]
    public class SchoolsController : BaseController<School>
    {
        public SchoolsController(SchoolDbContext context) : base(context) {}

        protected override DbSet<School> Set => _context.Schools;
    }
}
