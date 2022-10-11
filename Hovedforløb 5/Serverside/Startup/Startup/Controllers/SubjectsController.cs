using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Startup.Controllers
{
    [Route("api/subjects")]
    public class SubjectsController : BaseController<Subject>
    {
        public SubjectsController(SchoolDbContext context) : base(context) {}

        protected override DbSet<Subject> Set => _context.Subjects;
    }
}
