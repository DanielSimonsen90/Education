using DanhoComponents;
using System.Windows.Controls;

namespace DanhosMessages.Components.UserControls
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class UCMessage : UserControl
    {
        public UCMessage(Message message)
        {
            InitializeComponent();
            this.Username.Text = string.Empty; //TODO: Get username from message.ID
            this.MessageContent.Text = message.Content;
        }
    }
}
