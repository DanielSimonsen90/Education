using Microsoft.AspNetCore.Mvc;
using NGC_API.ComponentController;
using NGC_Components;
using System.Collections.Generic;

namespace NGC_API.Controllers
{
    public class LoginController : ControllerBase
    {
        public ComponentControllerLogin Controller { get; }

        public LoginController() { }
        public LoginController(ComponentControllerLogin loginController) => Controller = loginController;

        [HttpGet]
        public IList<Login> Get() => Controller.GetMultiple();

        [HttpGet("{id}")]
        public Login Get(int id) => Controller.Get(id);

        [HttpPost]
        public Login Post([FromBody] Login login) => Controller.Add(login);

        [HttpPut("{id}")]
        public Login Put([FromBody] Login login) => Controller.Update(login);

        [HttpDelete("{id}")]
        public void Delete(int id) => Controller.Delete(id);
    }
}
