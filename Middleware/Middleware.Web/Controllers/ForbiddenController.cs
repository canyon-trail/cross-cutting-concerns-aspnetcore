using Microsoft.AspNetCore.Mvc;
using Middleware.Web.Exceptions;

namespace Middleware.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForbiddenController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new ForbiddenException();
        }
    }
}