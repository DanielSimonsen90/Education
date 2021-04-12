using System;
using DanhosMessages.Components;
using System.Windows;
using DanhosMessages.Components.Errors;

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
            if (string.IsNullOrEmpty(username)) throw new InvalidUsernameException("Please provide a username!");
            //TODO: Check if login is in DB

            return true;
        }
    }
}
