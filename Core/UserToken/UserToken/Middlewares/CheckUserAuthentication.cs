using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserToken.Middlewares
{
    public class CheckUserAuthentication : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            if (context.Request.Path.Value.Contains("GetData"))
            {
                if (context.Session.GetString("token") != context.Request.Headers["token"])
                   await context.Response.WriteAsync("Error");
                else await next(context);

            }
               

            else await next(context); 
        }
    }
}
