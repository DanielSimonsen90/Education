using System;
using DanhosMessages.Components;
using System.Windows;
using DanhosMessages.Components.Errors;
using DanhoComponents;

namespace DanhosMessages.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        public MainWindow Window { get; set; }

        public Login(MainWindow window)
        {
            InitializeComponent();
            Window = window;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = textBoxUsername.Text;
            try 
            { 
                if (ValidateLogin(username)) 
                    Window.Content = new Chat(Window, username); 
            }
            catch (InvalidLoginException error) { MessageBox.Show(error.Message, "Invalid Login", MessageBoxButton.OK); }
        }
        private bool ValidateLogin(string username)
        {
            //No username provided
            if (string.IsNullOrEmpty(username)) throw new InvalidUsernameException("Please provide a username!");
            
            //Find a user with that name
            User user = Window.DBAccess.Users.GetUser(u => u.Name == username);

            //If none was found, create a user with that name
            user ??= Window.DBAccess.Users.AddUser(new User(username));

            //Expected to return true; either with new or old user
            return user != null;
        }
    }
}
