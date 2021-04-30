using Microsoft.AspNetCore.Mvc;
using NGC_API.Repositories;
using NGC_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGC_API.Controllers
{
    public class UserController
    {
        public UserRepository Repository { get; }

        public UserController() { }
        public UserController(UserRepository userRepos) => Repository = userRepos;

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
