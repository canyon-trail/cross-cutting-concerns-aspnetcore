using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Middleware.Web.Exceptions;

namespace Middleware.Web
{
    public sealed class ExceptionTranslationMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionTranslationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException)
            {
                context.Response.StatusCode = 404;
            }
            catch (ForbiddenException)
            {
                context.Response.StatusCode = 403;
            }
            catch (ConcurrencyIssueException)
            {
                context.Response.StatusCode = 409;
            }
        }
    }
}
