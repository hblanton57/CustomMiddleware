using Web.Middleware;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {       
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.UseMiddleware<Middleware.Auth>();
        app.Run(async context =>
        {
            await context.Response.WriteAsync("User name: "+context.Request.HttpContext.Items["userName"]);
            await context.Response.WriteAsync("Password: "+context.Request.HttpContext.Items["userPassword"]);
        });
    }
}
