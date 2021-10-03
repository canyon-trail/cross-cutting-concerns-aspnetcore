using Microsoft.AspNetCore.Mvc;

namespace ActionFilters.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
    public class FulfillmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Pick(string id)
        {
            return Ok($"Item {id} picked for shipment");
        }
        
        [HttpGet]
        public IActionResult Unpick(string id)
        {
            return Ok($"Item {id} re-shelved");
        }

        [HttpGet]
        public IActionResult Ship(string id)
        {
            return Ok($"Shipment {id} sent");
        }
    }
}