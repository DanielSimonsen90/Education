using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Startup.Controllers
{
    [Route("api/students/prog")]
    public class ProgStudentController : BaseController<ProgStudent>
    {
        public ProgStudentController(SchoolDbContext context) : base(context)
        {
        }

        protected override DbSet<ProgStudent> Set => _context.ProgStudents;
    }
}
