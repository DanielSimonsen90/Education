using DanhoComponents;
using DanhosEntitties.DBControllers.Interfaces;
using System;
using System.Collections.Generic;

namespace DanhosEntitties.DBControllers
{
    public class UserController : Controller<User>, IUserController
    {
        public UserController(DanhosMessagesContext context) : base(context) {}
        protected override User AddIfNull(User user) => user ?? new User($"User{Get(u => u.Name.StartsWith("User")).Count}");

        public User AddUser(User user = null) => Insert(AddIfNull(user));

        public IList<User> GetUsers(Func<User, bool> predicate) => Get(predicate);
        public User GetUser(Func<User, bool> predicate) => Get(predicate)[0];
        public User GetUser(int id) => Get(id);

        public User UpdateUser(User user) => Update(user);
        public User UpdateUser(int id) => Update(id);

        public void DeleteUser(User user) => Delete(user);
        public void DeleteUser(int id) => Delete(id);
    }
}
