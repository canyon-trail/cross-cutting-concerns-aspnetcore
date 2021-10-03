using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControllerBaseClass.Web.Controllers.Fruits
{
    public abstract class FruitControllerBase : Controller
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Response.Headers["X-Fruit-Salad-Compatible"] = "true";
            
            await base.OnActionExecutionAsync(context, next);
        }
    }
}