using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace ITI.CURDAPI.Present
{
    class Program
    {
        static IHostBuilder CreateHostBuilder()
            => Host.CreateDefaultBuilder()
                   .ConfigureWebHostDefaults(webHost =>
                   {
                       webHost.UseStartup<Startup>();
                   });
        static void Main(string[] args)
        {
            CreateHostBuilder().Build().Run();
        }
    }
}
