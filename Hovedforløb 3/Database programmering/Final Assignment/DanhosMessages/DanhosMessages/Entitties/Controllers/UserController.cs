using DanhosMessages.Entitties.Components;

namespace DanhosMessages.Entitties.Controllers
{
    public class UserController : Controller<User>
    {
        public UserController(DanhosMessagesContext context) : base(context) { }

        protected override User AddIfNull(User user)
        {
            if (user == null)
            {
                var defaultUsers = GetMultiple(u => u.Name.StartsWith("User"));
                user = new User($"User{defaultUsers.Count}");
            }
            return user;
        }
    }
}
