using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace CoreAPIFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Of Application");
            CreateHostBuilder().Build().Run();
            Console.WriteLine("End Of Application");
        }

        static IHostBuilder CreateHostBuilder()
             => Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost.UseStartup<Startup>();
                });
    }
}
