using Microsoft.AspNetCore.Mvc;
using NGC_Components;
using System;
using System.Collections.Generic;
using NGC_API;
using System.Threading.Tasks;
using NGC_API.Repositories;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace NGC_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            OnLoginAttempt += OnLoginAttempted;
            OnLoginSuccessful += OnLoginSucceeded;
        }
        public IActionResult Index()
        {
            return View();
        }

        public delegate Task<Login> LoginAttempt(string username, string password);
        public event LoginAttempt OnLoginAttempt;
        private async Task<Login> OnLoginAttempted(string username, string password)
        {
            string LoginsFromApiURI = "https://localhost:44327/api/Login";

            string loginsRes = await new HttpClient().GetStringAsync(LoginsFromApiURI);
            IList<Login> logins = new List<Login>() { new Login("admin", "admin") };
            if (logins == null || logins.Count == 0) throw new Exception("No logins found!");

            Login loginFromLogins = (logins as List<Login>).Find(l => l.Username == username && l.Password == password);
            string loginRes = await Helper.GetData(44327, $"Logins/{loginFromLogins.ID}");

            if (loginFromLogins != null) OnLoginSuccessful.Invoke(loginFromLogins);
            return loginFromLogins;
        }

        public delegate void LoginSuccessful(Login login);
        public event LoginSuccessful OnLoginSuccessful;
        private void OnLoginSucceeded(Login login)
        {
            _logger.LogInformation($"{login.Username} successfully logged in", login);

        }


        public async Task<Login> CreateLogin(string username, string password)
        {
            User user = new (new Login(username, password));
            //await Task.WhenAll(
            //    APIUserController.Post(user),
            //    APIController.Post(user.Login)
            //);
            return await OnLoginAttempt.Invoke(username, password);
        }
        public async Task<Login> Login(string username, string password) => await OnLoginAttempt.Invoke(username, password);
    }
}
