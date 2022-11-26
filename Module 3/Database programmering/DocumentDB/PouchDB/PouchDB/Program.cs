using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace PouchDB
{
    class Program
    {
         private static void Main(string[] args)
        {
            Todo t = new Todo("Gå i bad");

            string json = JsonSerializer.Serialize(t);
            PostJSON(json, "http://");
            Console.WriteLine("Hello World!");
        }

        private static void PostJSON(string json, string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            string username = "admin", password = username;
            httpWebRequest.Credentials = new NetworkCredential(username, password);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
