using ORM.Literal_ORM;

namespace ORM
{
    public class Item : MyORM
    {
        static Item()
        {
            Number(TABLE_NAME, "id", orm => (orm as Item).ID);
            Text(TABLE_NAME, "title", orm => (orm as Item).Title);
            Number(TABLE_NAME, "cost", orm => (orm as Item).Cost);
            Text(TABLE_NAME, "description", orm => (orm as Item).Description);
            PrimaryKey(TABLE_NAME, "id");
        }

        public static string TABLE_NAME => "items";
        public override string TableName => TABLE_NAME;


        public string Title { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }

        public Item(string title, float cost, string description)
        {
            Title = title;
            Cost = cost;
            Description = description;
        }
    }
}
