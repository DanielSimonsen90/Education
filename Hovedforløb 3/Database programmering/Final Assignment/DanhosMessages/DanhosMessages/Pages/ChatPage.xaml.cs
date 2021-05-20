using DanhosMessages.Entitties.Components;
using DanhosMessages.Components.Errors;
using DanhosMessages.Components.UserControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DanhosMessages.Entitties.Controllers;
using System.Threading;
using DanhosMessages.Entitties;
using DanhoLibrary;
using DanhoLibrary.Extensions;

namespace DanhosMessages.Pages
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        public MainWindow Window { get; set; }
        public User User { get; set; }
        public Chat Chat { get; set; }

        public ChatPage(MainWindow window, User user)
        {
            InitializeComponent();
            Window = window;
            User = user;
            SetChatUI();
        }

        private void SetUsername() => MessagingAs.Text = $"{MessagingAs.Text.Split(':')[0]}: {User.Name}";
        private void LoadMessages()
        {
            ChatController chatController = DBAccess.Database.Chats;

            int chatID = ChatIDs.SelectedIndex;
            Chat chat = chatController.Get(chatID);
            if (chat == null) chat = chatController.Add();

            if (chat.Messages is not List<Message> messages || messages.Count == 0) return;

            MessageContainer.Children.Clear();
            messages.ForEach(m => MessageContainer.Children.Add(new UCMessage(m)));
        }
        private void SetChatUI()
        {
            ChatController chatController = DBAccess.Database.Chats;

            SetUsername();
            List<Chat> chats = chatController.GetMultiple() as List<Chat>;
            Chat = chats == null ? chatController.Add() : chats.Find(c => c.ID == 0);
            var chatIDs = chats == null ? new int[] { 0 } : chats.Map(c => c.ID);
            chatIDs.ForEach(id => ChatIDs.Items.Add(id));
            LoadMessages();
        }

        private void Message_Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Message message = AddMessageToMessageContainer();
                ClearUserInput();
                DBAccess.Database.Messages.Add(message);
            }
            catch (InvalidMessageException error) { MessageBox.Show(error.Message, "Invalid Message", MessageBoxButton.OK); }

        }
        private Message AddMessageToMessageContainer()
        {
            string messageContent = MessageContent.Text;

            if (User == null) throw new InvalidMessageException("You are not logged in!");
            else if (string.IsNullOrEmpty(messageContent)) throw new InvalidMessageException("Please write something to send!");

            Message message = new(User, Chat, messageContent);
            MessageContainer.Children.Add(new UCMessage(message));
            return message;
        }
        private void ClearUserInput() => MessageContent.Text = string.Empty;

        private void Log_Out_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult userResponse = MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButton.YesNo);

            if (userResponse == MessageBoxResult.Yes)
                Window.Content = new LoginPage(Window);
        }
        private void ChatIDs_SelectionChanged(object sender, SelectionChangedEventArgs e) => SetChatUI();
    }
}
