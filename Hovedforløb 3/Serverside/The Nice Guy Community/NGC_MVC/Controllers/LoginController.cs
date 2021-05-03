using Microsoft.AspNetCore.Mvc;
using NGC_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGC_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public Login CreateLogin(string username, string password)
        {
            throw new NotImplementedException();
        }
        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

    }
}
