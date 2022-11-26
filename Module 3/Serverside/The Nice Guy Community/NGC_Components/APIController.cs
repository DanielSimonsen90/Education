using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NGC_Components
{
    public class APIController
    {
        public WebClient Client { get; }
        public int Port { get; }
        public string GetPath(string fromApi) => $"https://localhost:{Port}/api/{fromApi}";

        public APIController(int port = 44327)
        {
            Port = port;
            Client = new WebClient();
        }
        public async Task<Model> Get<Model>(string path)
        {
            string data = await Client.DownloadStringTaskAsync(GetPath(path));
            return JsonConvert.DeserializeObject<Model>(data);
        }
    }
}
