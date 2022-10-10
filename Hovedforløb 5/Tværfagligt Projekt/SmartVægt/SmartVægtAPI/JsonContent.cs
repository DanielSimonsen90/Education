using System.Text;
using System.Text.Json;

namespace SmartWeightAPI
{
    public class JsonContent : StringContent
    {
        public JsonContent(object content) : base(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
        {
        }
    }
}
