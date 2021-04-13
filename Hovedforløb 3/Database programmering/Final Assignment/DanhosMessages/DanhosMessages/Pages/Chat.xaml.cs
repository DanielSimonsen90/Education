using DanhoComponents;
using DanhosMessages.Components.Errors;
using DanhosMessages.Components.UserControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            User = window.DBAccess.Users.GetUser(u => u.Name == username);
            LoadMessages();
        }

        private void Message_Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Message message = AddMessageToMessageContainer();
                ClearUserInput();
                Window.DBAccess.Messages.AddMessage(message);
            }
            catch (InvalidMessageException error) { MessageBox.Show(error.Message, "Invalid Message", MessageBoxButton.OK); }

        }
        private Message AddMessageToMessageContainer()
        {
            string messageContent = MessageContent.Text;

            if (User == null) throw new InvalidMessageException("You are not logged in!");
            else if (string.IsNullOrEmpty(messageContent)) throw new InvalidMessageException("Please write something to send!");

            Message message = new(User, messageContent);
            MessageContainer.Children.Add(new UCMessage(message));
            return message;
        }
        private void ClearUserInput() => MessageContent.Text = string.Empty;

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
            List<Message> messages = Window.DBAccess.Chats.GetChat(chatID).Messages as List<Message>;
            if (messages.Count == 0) return;

            MessageContainer.Children.Clear();
            messages.ForEach(m => MessageContainer.Children.Add(new UCMessage(m)));
        }
    }
}
