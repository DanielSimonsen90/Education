using DanhoLibrary.EFController;
using NGC_Components;
using NGC_Components.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGC_API.ComponentController
{
    public class ComponentControllerUser : ControllerAsync<User>
    {
        public ComponentControllerUser(DanhoDBContext context) : base(context) { }

        public async override Task<User> Add(User user) => await base.Add(user);
        protected override User AddIfNull(User user)
        {
            if (user is null) throw new InvalidUserException("User cannot be null");
            return user;
        }
        public async override Task<User> Get(Func<User, bool> predicate) => await base.Get(predicate);
        public async override Task<User> Get(int id) => await base.Get(id);
        public async override Task<IList<User>> GetMultiple(Func<User, bool> predicate = null) => await base.GetMultiple(predicate);
        public async override Task<User> Update(User user) => await base.Update(user);
        public async override Task Delete(User user) => await base.Delete(user);
        public async override Task Delete(int id) => await base.Delete(id);
    }
}
