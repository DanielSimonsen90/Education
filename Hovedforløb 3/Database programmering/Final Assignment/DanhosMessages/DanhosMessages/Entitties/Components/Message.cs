using System.ComponentModel.DataAnnotations;

namespace DanhosMessages.Entitties.Components
{
    public class Message : HasID
    {
        [Key]
        public override int ID { get; set; }
        [Required]
        public User Sender { get; set; }
        [Required]
        public Chat Chat { get; set; }

        [Required]
        public string Content { get; set; }

        public Message(User sender, Chat chat, string content)
        {
            Sender = sender;
            Chat = chat;
            Content = content;
        }
        public Message() {}
    }
}