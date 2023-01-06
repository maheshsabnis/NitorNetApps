using Core_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
    [Route("api/[controller]/[action]")]
    // [ApiController]
    public class MBController : ControllerBase
    {
        NitorShopDbContext context;

        public MBController(NitorShopDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// http://localhost:7069/api/MB/PostFromBody
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PostFromBody")]
        public IActionResult PostFromBody([FromBody] Category category)
        {
            return Ok();
        }


        [HttpPost]
        // public IActionResult Post(string catId, string catName, int price)
        [ActionName("PostFromQuery")]
        public IActionResult PostFromQuery([FromQuery] Category category)
        {
            //Category cat = new Category() 
            //{
            //  CategoryId= catId,
            //  CategoryName= catName,
            //  BasePrice= price
            //};
            return Ok();
        }
        [HttpPost("{CategoryId}/{CategoryName}/{BasePrice}")]
        // public IActionResult Post(string catId, string catName, int price)
        [ActionName("PostFromRoute")]
        public IActionResult PostFromRoute([FromRoute] Category category)
        {
            //Category cat = new Category() 
            //{
            //  CategoryId= catId,
            //  CategoryName= catName,
            //  BasePrice= price
            //};
            return Ok();
        }

    }
}
