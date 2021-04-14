using System.Windows;
using DanhosMessages.Components.Errors;
using DanhosMessages.Entitties;
using DanhosMessages.Entitties.Components;
using DanhosMessages.Entitties.Controllers;

namespace DanhosMessages.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginPage
    {
        public MainWindow Window { get; set; }

        public LoginPage(MainWindow window)
        {
            InitializeComponent();
            Window = window;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = textBoxUsername.Text;
            try 
            { 
                if (ValidateLogin(username, out User user)) 
                    Window.Content = new ChatPage(Window, user); 
            }
            catch (InvalidLoginException error) { MessageBox.Show(error.Message, "Invalid Login", MessageBoxButton.OK); }
        }
        private static bool ValidateLogin(string username, out User user)
        {
            UserController userController = DBAccess.Database.Users;

            //No username provided
            if (string.IsNullOrEmpty(username)) throw new InvalidUsernameException("Please provide a username!");
            
            //Find a user with that name
            user = userController.Get(u => u.Name == username);

            //If none was found, create a user with that name
            user ??= userController.Add(new User(username));

            //Expected to return true; either with new or old user
            return user != null;
        }
    }
}
