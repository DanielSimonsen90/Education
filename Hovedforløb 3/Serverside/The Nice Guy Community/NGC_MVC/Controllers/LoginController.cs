using Microsoft.AspNetCore.Mvc;
using NGC_Components;
using System;
using System.Collections.Generic;
using NGC_API;
using System.Threading.Tasks;
using NGC_API.Repositories;

namespace NGC_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<Login> CreateLogin(string username, string password)
        {
            User user = new (new Login(username, password));
            //await Task.WhenAll(
            //    APIUserController.Post(user),
            //    APIController.Post(user.Login)
            //);
            return user.Login;
        }
        public async Task<Login> Login(string username, string password)
        {
            //IList<Login> logins = await APIController.Get();
            IList<Login> logins = new List<Login>() { new Login("admin", "admin") };
            if (logins == null || logins.Count == 0) throw new Exception("No logins found!");

            return (logins as List<Login>).Find(l => l.Username == username && l.Password == password);
        }
    }
}
