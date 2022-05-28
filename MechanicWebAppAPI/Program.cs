using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace MechanicWebAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {   // uncomment this two lines, to deploy on heroku
                    //  var port = Environment.GetEnvironmentVariable("PORT");

                    webBuilder.UseStartup<Startup>();
                   // .UseUrls("http://*:" + port);
                });
    }
}
