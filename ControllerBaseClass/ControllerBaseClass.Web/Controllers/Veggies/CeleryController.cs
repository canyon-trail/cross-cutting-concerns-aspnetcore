using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseClass.Web.Controllers.Veggies
{
    [FruitSalad]
    [ApiController]
    [Route("[controller]")]
    public class CeleryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Crisp crunchy celery");
        }
    }
}