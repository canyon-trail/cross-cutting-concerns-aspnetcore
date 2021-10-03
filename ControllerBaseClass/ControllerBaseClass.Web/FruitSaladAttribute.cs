using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControllerBaseClass.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class FruitSaladAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers["X-Fruit-Salad-Compatible"] = "true";
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
