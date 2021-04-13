using DanhoComponents;
using DanhosMessages.Components.Errors;
using DanhosMessages.Components.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DanhosMessages.Pages
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Page
    {
        public MainWindow Window { get; set; }
        public User User { get; set; }

        public Chat(MainWindow window, string username)
        {
            InitializeComponent();
            Window = window;
            //TODO: Find user from username
            //User = username;
            LoadMessages();
        }

        private void Message_Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddMessageToMessageContainer();
                ClearUserInput();
            }
            catch (InvalidMessageException error) { MessageBox.Show(error.Message, "Invalid Message", MessageBoxButton.OK); }
        }
        private void AddMessageToMessageContainer()
        {
            string messageContent = MessageContent.Text;

            if (User == null) throw new InvalidMessageException("You are not logged in!");
            else if (string.IsNullOrEmpty(messageContent)) throw new InvalidMessageException("Please write something to send!");

            MessageContainer.Children.Add(new UCMessage(new Message(User, messageContent)));
        }
        private void ClearUserInput()
        {
            MessageContent.Text = string.Empty;
        }

        private void Log_Out_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult userResponse = MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButton.YesNo);

            if (userResponse == MessageBoxResult.Yes)
                Window.Content = new Login(Window);
        }

        private void ChatIDs_SelectionChanged(object sender, SelectionChangedEventArgs e) => LoadMessages();
        private void LoadMessages()
        {
            int chatID = ChatIDs.SelectedIndex;
            //TODO: Load messages from chatID
            List<Message> messages = new();
            if (messages.Count == 0) return;

            MessageContainer.Children.Clear();
            messages.ForEach(m => MessageContainer.Children.Add(new UCMessage(m)));
        }
    }
}
