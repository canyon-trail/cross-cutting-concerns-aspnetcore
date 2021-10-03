using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseClass.Web.Controllers.Proteins
{
    [ApiController]
    [FruitSalad]
    [Route("[controller]")]
    public class WalnutController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Crunchy savory walnut");
        }
    }
}