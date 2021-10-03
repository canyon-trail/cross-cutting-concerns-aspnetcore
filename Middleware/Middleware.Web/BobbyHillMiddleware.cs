using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware.Web
{
    public sealed class BobbyHillMiddleware
    {
        private readonly RequestDelegate _next;

        public BobbyHillMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/bobbyhill"))
            {
                context.Response.StatusCode = 418;

                await context.Response.WriteAsync("That's my purse!");
                await context.Response.WriteAsync("I don't know you!");

                return;
            }

            await _next(context);
        }
    }
}
