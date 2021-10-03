using Microsoft.AspNetCore.Mvc;

namespace ActionFilters.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Search()
        {
            return Ok("Catalog search results");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ItemDetails(string id)
        {
            return Ok($"Details for item {id}");
        }
    }
}
