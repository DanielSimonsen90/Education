using Microsoft.AspNetCore.Mvc;
using NGC_API.Repositories;
using NGC_Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        protected LoginRepository Repository { get; }

        public LoginController() => Repository = new LoginRepository(Program.Context);

        [HttpGet]
        public async Task<ActionResult<IList<Login>>> Get() => new ActionResult<IList<Login>>(await Repository.GetMultiple());
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> Get(int id) => new ActionResult<Login>(await Repository.Get(id));

        [HttpPost]
        public Task<Login> Post([FromBody] Login login) => Repository.Add(login);

        [HttpPut("{id}")]
        public Task<Login> Put([FromBody] Login login) => Repository.Update(login);

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Repository.Delete(id);
        }
    }
}
