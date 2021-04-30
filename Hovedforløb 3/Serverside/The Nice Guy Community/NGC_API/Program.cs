using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NGC_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (UserContext context = new())
            {

            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
