using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseClass.Web.Controllers.Proteins
{
    [ApiController]
    [Route("[controller]")]
    public class EggController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Farm-fresh egg");
        }
    }
}