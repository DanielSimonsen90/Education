using Microsoft.AspNetCore.Mvc;
using NGC_API.Repositories;
using NGC_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private UserRepository Repository { get; }

        public UserController() => Repository = new UserRepository(Program.Context);

        [HttpGet]
        public async Task<IList<User>> Get() => await Repository.GetMultiple();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id) => await Repository.Get(id);

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user) => await Repository.Add(user);

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put([FromBody] User user) => await Repository.Update(user);

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await Repository.Delete(id);
    }
}
