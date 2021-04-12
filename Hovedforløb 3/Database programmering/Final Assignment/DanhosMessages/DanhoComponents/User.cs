namespace DanhoComponents
{
    public class User : IID
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Chat Chat { get; set; }

        public User(string name) => Name = name;
    }
}