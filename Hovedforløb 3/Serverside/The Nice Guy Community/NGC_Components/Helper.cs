using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NGC_Components
{
    public static class Helper
    {
        public static async Task<string> GetData(int port, string path)
        {
            //using HttpClient client = new();
            //HttpResponseMessage res = await client.GetAsync(url);
            //HttpContent content = res.Content;
            //string data = await content.ReadAsStringAsync();
            //return data;

            string LoginsFromApiURI = $"https://localhost:{port}/api/{path}";
            return await new HttpClient().GetStringAsync(LoginsFromApiURI);
        }
    }
}
