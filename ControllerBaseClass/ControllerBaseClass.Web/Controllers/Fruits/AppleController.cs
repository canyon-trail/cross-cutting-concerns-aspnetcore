using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseClass.Web.Controllers.Fruits
{
    [ApiController]
    [Route("[controller]")]
    public class AppleController : FruitControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Crisp sweet apple");
        }
    }
}
