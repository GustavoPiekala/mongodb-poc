using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace MongoDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://admin:admin@localhost:27017/admin");

            var database = client.GetDatabase("admin");

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
