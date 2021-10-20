using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections;
using System.Security.Cryptography;

namespace DanielsPasswords
{
    public class Login
    {
        private static readonly SHA256 _hash = SHA256.Create();

        public static readonly string LoginsPath = "../../logins.json";
        public static List<Login> Logins => GetLogins();
        public static List<Login> AddLogin(string username, string password)
        {
            if (Logins.Find(l => l.Username == username) != null) throw new Exception("Username already exists");
            return SaveLogins(GetLogins().Append(new(username, Hash(username, password))).ToList());
        }
        private static List<Login> GetLogins()
        {
            try { return JsonSerializer.Deserialize<List<Login>>(File.ReadAllText(LoginsPath)); }
            catch { File.WriteAllText(LoginsPath, JsonSerializer.Serialize(new List<Login>())); }
            return GetLogins();
        }
        public static List<Login> SaveLogins(List<Login> logins)
        {
            File.WriteAllText(LoginsPath, JsonSerializer.Serialize(logins));
            return logins.ToList();
        }

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
