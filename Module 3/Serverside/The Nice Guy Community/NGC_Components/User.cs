using DanhoLibrary.EFController;
using System;
using System.ComponentModel.DataAnnotations;

namespace NGC_Components
{
    public class User : HasID
    {
        [Key]
        public override int ID { get; set; }
        public string Username { get; set; }
        public DateTime JoinedAt { get; set; }
        public Login Login { get; set; }

        public User(Login login)
        {
            Username = login.Username;
            JoinedAt = DateTime.Now;
            Login = login;
        }
    }
}
