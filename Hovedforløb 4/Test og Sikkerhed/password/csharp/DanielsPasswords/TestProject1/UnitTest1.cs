using System;
using Xunit;
using DanielsPasswords;
using System.Threading.Tasks;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void SignUp()
        {
            Login admin = new("Admin", "Admin");
            Login fakeAdmin = new("Admin", "Moderator");

            Assert.Equal(200, Program.OnSignUp(admin, false)); //Successfully created user admin with password admin
            Assert.Equal(404, Program.OnSignUp(fakeAdmin, false)); //Failed to login user admin with password moderator
            Assert.Equal(200, Program.OnSignUp(admin, false)); //Successfully logged user admin in with password admin
        }
        [Fact]
        public void Login()
        {
            Login invalidUser = new("Moderator", "Moderator");
            Login wrongUsername = new("Moderator", "Admin");
            Login wrongPassword = new("Admin", "Moderator");
            Login admin = new("Admin", "Admin");

            Program.OnSignUp(admin, false);

            Assert.Equal(404, Program.OnLogin(invalidUser, false)); //Failed to log moderator in - no user
            Assert.Equal(404, Program.OnLogin(wrongUsername, false)); //Failed to log moderator in - no such username
            Assert.Equal(404, Program.OnLogin(wrongPassword, false)); //Failed to log admin in - invalid password
            Assert.Equal(200, Program.OnLogin(admin, false)); //Successfully logged user admin in
        }
        [Fact]
        public void Injection()
        {
            string injection = "' OR 1=1; --";
            Login username = new(injection, "1234");
            Login password = new("1234", injection);
            Login both = new(injection, injection);

            Assert.Equal(404, Program.OnLogin(username, false)); //Failed to log moderator in - no user
            Assert.Equal(404, Program.OnLogin(password, false)); //Failed to log moderator in - no user
            Assert.Equal(404, Program.OnLogin(both, false)); //Failed to log moderator in - no user
        }
    }
}
