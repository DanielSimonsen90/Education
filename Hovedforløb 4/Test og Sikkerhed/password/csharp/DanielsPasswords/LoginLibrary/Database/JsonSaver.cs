using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LoginLibrary.Database
{
    public class JsonSaver : DatabaseSaver<Login>
    {
        public string Path { get; set; }
        public JsonSaver(string path) => Path = path;

        public override List<Login> FetchData()
        {
            try { return JsonSerializer.Deserialize<List<Login>>(File.ReadAllText(Path)); }
            catch { File.WriteAllText(Path, JsonSerializer.Serialize(new List<Login>())); }
            return FetchData();
        }
        public override List<Login> AddData(Login login) => OverrideData(FetchData().Append(login).ToList());
        protected List<Login> OverrideData(List<Login> logins)
        {
            File.WriteAllText(Path, JsonSerializer.Serialize(logins ?? FetchData()));
            return logins;
        }
        public override List<Login> DeleteData(Login login)
        {
            List<Login> logins = FetchData();
            Login match = logins.Find(l => l.Username == login.Username && l.Password == login.Password);
            return match == null || !logins.Remove(match) ? logins : OverrideData(logins);
        }

        public override void Die() => File.Delete(Path);
    }
}
