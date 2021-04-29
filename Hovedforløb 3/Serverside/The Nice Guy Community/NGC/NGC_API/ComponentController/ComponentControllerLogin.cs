using NGC_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanhoLibrary.EFController;

namespace NGC_API.ComponentController
{
    public class ComponentControllerLogin : Controller<Login>
    {
        public ComponentControllerLogin(DanhoDBContext context) : base(context) {}

        public override Login Add(Login login) => base.Add(login);
        protected override Login AddIfNull(Login login)
        {
            if (login is null) throw new InvalidLoginException("Login cannot be null");
            return login;
        }
        public override Login Get(Func<Login, bool> predicate) => base.Get(predicate);
        public override Login Get(int id) => base.Get(id);
        public override IList<Login> GetMultiple(Func<Login, bool> predicate = null) => base.GetMultiple(predicate);
        public override Login Update(Login login) => base.Update(login);
        public override void Delete(Login login) => base.Delete(login);
        public override void Delete(int id) => base.Delete(id);
    }
}
