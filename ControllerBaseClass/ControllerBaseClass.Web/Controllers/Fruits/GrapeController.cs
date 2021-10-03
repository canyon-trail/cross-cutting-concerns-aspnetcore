using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseClass.Web.Controllers.Fruits
{
    [ApiController]
    [Route("[controller]")]
    public class GrapeController : FruitControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Plump and juicy grape");
        }
    }
}
