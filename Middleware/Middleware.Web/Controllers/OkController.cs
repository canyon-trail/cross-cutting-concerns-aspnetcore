using Microsoft.AspNetCore.Mvc;

namespace Middleware.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OkController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This worked great!");
        }
    }
}
