using Microsoft.AspNetCore.Mvc;

namespace ActionFilters.Web.Controllers
{
    [ApiController]
    [AllowCustomer]
    [Route("[controller]/[action]/{id?}")]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Cart contents");
        }

        [HttpGet]
        public IActionResult Add(string id)
        {
            return Ok($"Added item {id} to cart");
        }

        [HttpGet]
        public IActionResult Clear()
        {
            return Ok("Cart cleared");
        }

    }
}
