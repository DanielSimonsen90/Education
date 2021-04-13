using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanhoComponents
{
    public class User : IID
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Chat> Chats { get; set; }

        public User(string name)
        {
            Name = name;
            Chats = new HashSet<Chat>();
        }
    }
}