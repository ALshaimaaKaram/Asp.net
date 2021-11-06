using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace UserToken
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDefaultBuilder().Build().Run();
        }

        static IHostBuilder CreateDefaultBuilder()
            => Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost.UseStartup<StartUp>();
                });
    }
}
