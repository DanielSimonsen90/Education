using System.ComponentModel.DataAnnotations;

namespace DanhoComponents
{
    public class Message : IID
    {
        [Key]
        public int ID { get; set; }
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