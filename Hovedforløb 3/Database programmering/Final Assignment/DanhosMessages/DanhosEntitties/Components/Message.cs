using System.ComponentModel.DataAnnotations;

namespace DanhosEntitties.Components
{
    public class Message : HasID
    {
        [Key]
        public override int ID { get; set; }
        [Key]
        public int SenderID { get; set; }
        [Required]
        public string Content { get; set; }

        public Message(User sender, string content)
        {
            SenderID = sender.ID;
            Content = content;
        }
    }
}