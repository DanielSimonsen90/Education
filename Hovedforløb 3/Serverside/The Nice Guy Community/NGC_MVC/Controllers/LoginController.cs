using Microsoft.AspNetCore.Mvc;
using NGC_Components;
using System;
using System.Collections.Generic;
using NGC_API;
using System.Threading.Tasks;
using NGC_API.Repositories;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using NGC_Components.Exceptions;

namespace NGC_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        public IList<Login> TempLogins = new List<Login>() { new Login("admin", "admin") };
        public APIController API = new();

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
            _logger.LogInformation("Executing OnLoginAttempted", username, password);
            string LoginsFromApiURI = "https://localhost:44327/api/Login";
            //string loginsRes = await new HttpClient().GetStringAsync(LoginsFromApiURI);

            string loginsRes = await API.Get("Login");
            IList<Login> logins = TempLogins;
            _logger.LogInformation("Fetched logins from Database", logins);

            if (logins == null || logins.Count == 0) throw new Exception("No logins found!");
            _logger.LogInformation("Validated entries in logins - logins is not empty", logins);

            Login loginFromLogins = (logins as List<Login>).Find(l => l.Username == username && l.Password == password);
            _logger.LogInformation("Looking for parameter credentials in logins list", loginFromLogins, username, password, logins);
            //string loginRes = await Helper.GetData(44327, $"Logins/{loginFromLogins.ID}");
            //_logger.LogInformation("Fetched User from database", login, loginFromLogins);

            _logger.LogInformation(loginFromLogins != null ? "Login exists - emitting OnLoginSuccessful" : "Login didn't exist - exiting");
            if (loginFromLogins != null)
                OnLoginSuccessful.Invoke(loginFromLogins);
            return loginFromLogins;
        }

        public delegate IActionResult LoginSuccessful(Login login);
        public event LoginSuccessful OnLoginSuccessful;
        private IActionResult OnLoginSucceeded(Login login)
        {
            _logger.LogInformation("Executing OnLoginSucceeded", login);
            _logger.LogInformation($"{login.Username} successfully logged in", login);
            return RedirectToPage("../Home/Index");
        }


        public async Task<Login> CreateLogin(string username, string password)
        {
            _logger.LogInformation("Executing CreateLogin", username, password);
            if (username == null || username == string.Empty) throw new InvalidLoginException("Username was not defined");
            else if (password == null || password == string.Empty) throw new InvalidLoginException("Password was not defined");
            _logger.LogInformation("Login credentials passed");

            User user = new (new Login(username, password));
            _logger.LogInformation("Created User object from parameters", username, password);
            //await Task.WhenAll(
            //    APIUserController.Post(user),
            //    APIController.Post(user.Login)
            //);
            TempLogins.Add(user.Login);
            _logger.LogInformation("Emitting OnLoginAttempt");
            return await OnLoginAttempt.Invoke(username, password);
        }
        public async Task<Login> Login(string username, string password) => await OnLoginAttempt.Invoke(username, password);
    }
}
