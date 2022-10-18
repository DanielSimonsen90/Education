using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVægtApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Command LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new(OnLogin); 
        }
        
        private void OnLogin()
        {
            
        }
    }
}
