using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using LoginLibrary.Database;
using System.Linq;

namespace LoginLibrary
{
    public class Login
    {
        private static readonly SHA256 _hash = SHA256.Create();
        public static readonly SQLSaver Saver = new(
            "DANIEL-SIMONSEN\\MASTERRUNEUWU",
            "H4HashStash", true, "Logins"
        );

        public static readonly string LoginsPath = "../../logins.json";
        public static List<Login> AddLogin(string username, string password)
        {
            string filter = $"Username = {SQLSaver.ResolveInjection(username)}";
            bool exists = Saver.FetchData(filter).FirstOrDefault() != null;
            if (exists) throw new Exception("Username already exists");
            else if (username.Length > 50 || password.Length > 50) throw new Exception($"Username or password are too long! Max characters are {SQLSaver.MaxChars}");
            
            return Saver.AddData(new(username, Hash(username, password)));
        }
        
        public static bool TryLogin(Login login) => FindMatch(login) != null;
        public static Login FindMatch(string query) => Saver.FetchData(query).FirstOrDefault();
        public static Login FindMatch(Login login) => FindMatch(
            $"Username = {SQLSaver.ResolveInjection(login.Username)} AND " + 
            $"Password = '{Hash(login.Username, login.Password)}'");

        public static string Hash(string username, string password) => Hash(Hash(username) + Hash(password));
        private static string Hash(string value) => Convert.ToBase64String(_hash.ComputeHash(Encoding.ASCII.GetBytes(value)));

        public string Username { get; set; }
        public string Password { get; set; }
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
