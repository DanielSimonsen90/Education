using Microsoft.AspNetCore.Mvc;
using NGC_API.Repositories;
using NGC_Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGC_API.Controllers
{
    public class LoginController : ControllerBase
    {
        public LoginRepository Repository { get; }

        public LoginController() { }
        public LoginController(LoginRepository loginRepos) => Repository = loginRepos;

        [HttpGet]
        public Task<IList<Login>> Get() => Repository.GetMultiple();

        [HttpGet("{id}")]
        public Task<Login> Get(int id) => Repository.Get(id);

        [HttpPost]
        public Task<Login> Post([FromBody] Login login) => Repository.Add(login);

        [HttpPut("{id}")]
        public Task<Login> Put([FromBody] Login login) => Repository.Update(login);

        [HttpDelete("{id}")]
        public Task Delete(int id) => Repository.Delete(id);
    }
}
