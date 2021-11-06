using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIFirst
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello");
                    context.Response.WriteAsync("HelloSec");
                });

                endpoints.MapGet("/List", context =>

                  context.Response.WriteAsync("My List")
                );
            });

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Authentication\n");
            //    await next();
            //    await context.Response.WriteAsync("Authentication 2\n");
            //});


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("End Of Request \n");
            //});


            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Authorization\n");
            //    await next();
            //    await context.Response.WriteAsync("Authorization 2\n");
            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

        }
    }
}
