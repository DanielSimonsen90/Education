using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DanielsPasswords.Database
{
    public class JsonSaver : DatabaseSaver<Login>
    {
        public string Path { get; set; }
        public JsonSaver(string path)
        {
            Path = path;
            Cache = FetchData();
        }

        public override List<Login> FetchData()
        {
            try { return JsonSerializer.Deserialize<List<Login>>(File.ReadAllText(Path)); }
            catch { File.WriteAllText(Path, JsonSerializer.Serialize(new List<Login>())); }
            return FetchData();
        }
        public override List<Login> AddData(Login login) => OverrideData(Cache.Append(login).ToList());
        protected List<Login> OverrideData(List<Login> logins)
        {
            File.WriteAllText(Path, JsonSerializer.Serialize(logins ?? Cache));
            return Cache = logins;
        }
        public override List<Login> DeleteData(Login login) => 
            !Cache.Contains(login) || !Cache.Remove(login) ? 
                Cache : 
                OverrideData(Cache);

        public override void Die() => File.Delete(Path);
    }
}
