using EntityFrameworkFun.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EntityFrameworkFun
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (WebshopContext context = new())
            {
                var basket = new Basket();
                var kage = new Item(title: "Simon's sandkage", cost: 420, description: "Simon er generelt glad for kage");

                basket.Items.Add(kage);
                context.Baskets.Add(basket);

                context.SaveChanges();
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
