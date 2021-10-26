using System;
using Xunit;
using DanielsPasswords;
using System.Threading.Tasks;

namespace TestProject1
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            DanielsPasswords.Login.Saver.Die();
        }

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
    }
}
