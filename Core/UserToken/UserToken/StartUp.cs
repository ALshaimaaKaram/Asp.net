using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserToken.Extentions;
using UserToken.Middlewares;

namespace UserToken
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.Cookie.Name = ".AdventureWorks.Session";
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.IsEssential = true;
            //});
            services.AddSession();
            services.AddTransient<CheckUserAuthentication>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                app.UseCheckUserAuthentication();
            });

        }
    }
}
