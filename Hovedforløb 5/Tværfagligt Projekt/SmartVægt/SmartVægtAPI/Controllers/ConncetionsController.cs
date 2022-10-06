using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Models;

namespace SmartWeightAPI.Controllers
{
    [Route("api/[controller]/{userId}")]
    public class ConncetionsController : BaseModelController<Connection>
    {
        [HttpPost("{weightId}")]
        public IActionResult Connect(int weightId, int userId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetConnection(int userId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Disconnect(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
