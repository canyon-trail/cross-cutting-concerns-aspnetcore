using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseClass.Web.Controllers.Fruits
{
    [ApiController]
    [Route("[controller]")]
    public class StrawberryController : FruitControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Sweet and tangy strawberry");
        }
    }
}
