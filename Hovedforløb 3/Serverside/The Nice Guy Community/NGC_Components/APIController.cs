using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NGC_Components
{
    public class APIController
    {
        public HttpClient Client { get; }

        public APIController(int port = 44327)
        {
            HttpClientHandler handler = new()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (message, cert, cetChain, policyErr) => true
            };
            Client = new HttpClient(handler) 
            {
                BaseAddress = new Uri($"https://localhost:{port}/api/")
            };
        }
        public async Task<string> Get(string path)
        {
            HttpResponseMessage res = await Client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (!res.IsSuccessStatusCode) throw new Exception("Response unsuccessfull");

            string data = await res.Content.ReadAsStringAsync();
            return data;
            //return await new HttpClient().GetStringAsync(url);

        }
    }
}
