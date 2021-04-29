using Microsoft.AspNetCore.Mvc;
using NGC_API.ComponentController;
using NGC_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGC_API.Controllers
{
    public class UserController
    {
        public ComponentControllerUser Controller { get; }

        public UserController() { }
        public UserController(ComponentControllerUser userController) => Controller = userController;

        [HttpGet]
        public async Task<IList<User>> Get() => await Controller.GetMultiple();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id) => await Controller.Get(id);

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user) => await Controller.Add(user);

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put([FromBody] User user) => await Controller.Update(user);

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await Controller.Delete(id);
    }
}
