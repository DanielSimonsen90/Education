using NGC_Components;
using System;
using System.Collections.Generic;
using NGC_Components.Exceptions;
using System.Threading.Tasks;
using DanhoLibrary.EFController;

namespace NGC_API.Repositories
{
    public class LoginRepository : RepositoryAsync<Login>
    {
        public LoginRepository(DanhoDBContext context) : base(context) {}

        public override Task<Login> Add(Login login) => base.Add(login);
        protected override Login AddIfNull(Login login)
        {
            if (login is null) throw new InvalidLoginException("Login cannot be null");
            return login;
        }
        public override Task<Login> Get(Func<Login, bool> predicate) => base.Get(predicate);
        public override Task<Login> Get(int id) => base.Get(id);
        public override Task<IList<Login>> GetMultiple(Func<Login, bool> predicate = null) => base.GetMultiple(predicate);
        public override Task<Login> Update(Login login) => base.Update(login);
        public override Task Delete(Login login) => base.Delete(login);
        public override Task Delete(int id) => base.Delete(id);
    }
}
