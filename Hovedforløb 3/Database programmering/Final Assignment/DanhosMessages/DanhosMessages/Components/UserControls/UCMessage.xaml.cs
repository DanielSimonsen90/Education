using DanhosMessages.Entitties.Components;
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
            this.Username.Text = message.Sender.Name;
            this.MessageContent.Text = message.Content;
        }
    }
}
