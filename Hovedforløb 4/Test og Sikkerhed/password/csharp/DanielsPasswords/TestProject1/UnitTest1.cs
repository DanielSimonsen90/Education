using System;
using Xunit;
using DanielsPasswords;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void SignUp()
        {
            Login admin = new("Admin", "Admin");
            Login fakeAdmin = new("admin", "moderator");

            Assert.Equal(200, Program.OnSignUp(admin, false)); //Successfully created user admin with password admin
            Assert.Equal(0, Program.OnSignUp(fakeAdmin, false)); //Failed to login user admin with password moderator
            Assert.Equal(200, Program.OnSignUp(admin, false)); //Successfully logged user admin in with password admin
        }
        [Fact]
        public void Login()
        {
            Login invalidUser = new("moderator", "moderator");
            Login wrongUsername = new("moderator", "admin");
            Login wrongPassword = new("admin", "moderator");
            Login admin = new("Admin", "Admin");

            Program.OnSignUp(admin, false);

            Assert.Equal(404, Program.OnLogin(invalidUser, false)); //Failed to log moderator in - no user
            Assert.Equal(404, Program.OnLogin(wrongUsername, false)); //Failed to log moderator in - no such username
            Assert.Equal(404, Program.OnLogin(wrongPassword, false)); //Failed to log admin in - invalid password
            Assert.Equal(200, Program.OnLogin(admin, false)); //Successfully logged user amdin in
        }
    }
}
