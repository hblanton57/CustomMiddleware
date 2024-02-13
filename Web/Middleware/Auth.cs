using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Middleware
{
    public class Auth
    {
        private readonly RequestDelegate _next;
        public Auth(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query["username"] == "user1" && context.Request.Query["password"] == "password1")
            {
                context.Request.HttpContext.Items.Add("userName", "user1");
                context.Request.HttpContext.Items.Add("password", "password1");
                await _next(context);
            }
            else {
                await context.Response.WriteAsync("Failed!");
            }
        }
    }
}