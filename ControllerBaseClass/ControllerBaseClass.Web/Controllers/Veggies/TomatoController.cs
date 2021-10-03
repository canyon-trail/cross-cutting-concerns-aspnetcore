using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseClass.Web.Controllers.Veggies
{
    [ApiController]
    [Route("[controller]")]
    public class TomatoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Firm and ripe tomato");
        }
    }
}