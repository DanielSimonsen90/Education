using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Startup.Controllers
{
    [Route("api/students/it")]
    public class ITStudentController : BaseController<ITStudent>
    {
        public ITStudentController(SchoolDbContext context) : base(context)
        {
        }

        protected override DbSet<ITStudent> Set => _context.ITStudents;
    }
}
