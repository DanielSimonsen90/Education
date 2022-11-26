using System;
using System.Net;
using System.Text;
using System.IO;

namespace MyWebserver
{
    public class DanhoServer
    {
        private string WebsiteDir { get; }

        public DanhoServer(string websiteDir = "Websites") 
        {
            WebsiteDir = websiteDir;
        }

        public delegate string HttpMethodEvent(string url, HttpListenerRequest request, HttpListenerResponse response);
        public event HttpMethodEvent OnPost, OnGet, OnPut, OnDelete;

        public void ListenTo(params string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // URI prefixes are required,
            // for example "http://contoso.com:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("Prefixes cannot be null or empty");

            // Create a listener.
            HttpListener listener = new();
            // Add the prefixes.
            foreach (string prefix in prefixes)
                listener.Prefixes.Add(prefix);
            listener.Start();
            while (true) Listen(listener);
            //listener.Stop();
        }
        public virtual string EventHandler_OnGet(string url, HttpListenerRequest req, HttpListenerResponse res)
        {
            Console.WriteLine($"Path handling with url: {url}");

            string[] Folders = new string[] { ".", "./Websites", $"./{WebsiteDir}" };

            try { return File.ReadAllText($"{Folders[0]}{url}"); }
            catch 
            {
                try { return File.ReadAllText($"{Folders[1]}{url}"); }
                catch { return File.ReadAllText($"{Folders[2]}{url}"); }
            }
        }
        
        private void Listen(HttpListener listener)
        {
            Console.WriteLine("Listening...");

            // Note: The GetContext method blocks while waiting for a request.
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;

            // Construct a response.
            string responseString = Emit(request.RawUrl, context);
            Console.WriteLine($"responseString recieved: {responseString}");
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);


            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            // You must close the output stream.
            //response.Close();
            output.Close();
        }
        private string Emit(string url, HttpListenerContext context)
        {
            Console.WriteLine($"Path \"{url}\" emitted.");
            return GetEvent(context.Request.HttpMethod).Invoke(url, context.Request, context.Response);
        }
        private HttpMethodEvent GetEvent(string httpMethod) =>
            httpMethod switch
            {
                "POST" => OnPost,
                "GET" => OnGet,
                "PUT" => OnPut,
                "DELETE" => OnDelete,
                _ => throw new Exception($"HTTP Type, {httpMethod}, is not a valid type!"),
            };
    }

    public enum HttpMethods { POST, GET, PUT, DELETE }
}
