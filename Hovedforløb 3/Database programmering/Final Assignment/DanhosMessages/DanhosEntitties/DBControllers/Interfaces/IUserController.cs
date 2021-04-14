using DanhosEntitties.Components;
using System;
using System.Collections.Generic;

namespace DanhosEntitties.DBControllers.Interfaces
{
    interface IUserController
    {
        User AddUser(User user = null);
        
        IList<User> GetUsers(Func<User, bool> predicate);
        User GetUser(Func<User, bool> predicate);
        User GetUser(int id);

        User UpdateUser(User user);
        User UpdateUser(int id);

        void DeleteUser(User user);
        void DeleteUser(int id);
    }
}
