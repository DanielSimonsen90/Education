namespace DanhoComponents
{
    public class Message : IID
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public string Content { get; set; }

        public Message(User sender, string content)
        {
            SenderID = sender.ID;
            Content = content;
        }
    }
}