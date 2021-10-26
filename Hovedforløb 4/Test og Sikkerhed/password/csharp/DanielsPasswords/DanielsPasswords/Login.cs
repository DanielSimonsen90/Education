using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using DanielsPasswords.Database;

namespace DanielsPasswords
{
    public class Login
    {
        private static readonly SHA256 _hash = SHA256.Create();
        public static readonly DatabaseSaver<Login> Saver = new SQLSaver(
            "DANIEL-SIMONSEN\\MASTERRUNEUWU",
            "H4HashStash", true, "Logins"
        );

        public static readonly string LoginsPath = "../../logins.json";
        public static List<Login> Logins => Saver.GetData();
        public static List<Login> AddLogin(string username, string password)
        {
            if (Logins.Find(l => l.Username == username) != null) throw new Exception("Username already exists");
            else if (username.Length > 50 || password.Length > 50) throw new Exception($"Username or password are too long! Max characters are {SQLSaver.MaxChars}");
            
            return Saver.AddData(new(username, Hash(username, password)));
        }
        
        public static bool TryLogin(Login login) => FindMatch(login) != null;
        public static Login FindMatch(Predicate<Login> predicate) => Logins.Find(predicate);
        public static Login FindMatch(Login login) => FindMatch(l => 
            l.Username == login.Username &&
            Hash(login.Username, login.Password) == l.Password
        );

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
