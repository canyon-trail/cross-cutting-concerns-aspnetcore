using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilters.Web
{
    // WARNING! THIS IS HORRIBLY INSECURE AND NOT SUITABLE FOR REAL SECURITY
    public sealed class AuthorizeAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var allowsAnonymous = context.Filters.Any(x => x is AllowAnonymousAttribute);
            if (allowsAnonymous)
            {
                return;
            }

            var authHeaderValues = context.HttpContext.Request.Headers["X-Custom-Auth"];
            var isAdmin = authHeaderValues.Contains("Admin");
            var isAuthenticated = authHeaderValues.Count > 0;

            var allowsCustomer = context.Filters.Any(x => x is AllowCustomerAttribute);

            if(isAuthenticated && (isAdmin || allowsCustomer))
            {
                return;
            }

            context.Result = new StatusCodeResult(401);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
