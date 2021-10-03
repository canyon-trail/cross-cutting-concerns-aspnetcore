using Microsoft.AspNetCore.Mvc;

namespace ActionFilters.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Level(string id)
        {
            return Ok($"Current inventory level of {id}");
        }

        [HttpGet]
        public IActionResult Restock(string id)
        {
            return Ok($"Restocked {id}");
        }

        [HttpGet]
        [AllowCustomer]
        public IActionResult ValidateCart()
        {
            return Ok("Inventory levels validated for cart contents");
        }
    }
}
