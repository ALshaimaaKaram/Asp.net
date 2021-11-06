using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserToken.Middlewares;

namespace UserToken.Extentions
{
    public static class MiddlewareExtentions
    {
        public static void UseCheckUserAuthentication(this IApplicationBuilder app)
        {
            app.UseMiddleware<CheckUserAuthentication>();
        }
    }
}
