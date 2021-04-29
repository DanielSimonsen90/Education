using DanhoLibrary.EFController;
using System.ComponentModel.DataAnnotations;

namespace NGC_Components
{
    public class Login : HasID
    {
        [Key]
        public override int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User User { get; set; }

        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
