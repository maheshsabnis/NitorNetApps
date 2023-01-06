using Core_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_API.Controllers
{
    [Route("api/[controller]")]
    /// USed to Map the Received JSON Data from Http POST and PUT Request to CLR
    /// Object
    [ApiController]
    public class ProductController : ControllerBase
    {
        NitorShopDbContext context;

        public ProductController(NitorShopDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var record = await context.Products.ToListAsync();
            return Ok(record);
        }
        /// <summary>
        /// The URL Parameter as a Template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var record = await context.Products.FindAsync(id);
            return Ok(record);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Product data)
        {
            if (ModelState.IsValid)
            {
                var record = await context.Products.AddAsync(data);
                await context.SaveChangesAsync();
                return Ok(record.Entity);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product data)
        {
            if (ModelState.IsValid)
            {
                var record = await context.Products.FindAsync(id);
                if (record != null)
                {
                    record.ProductId = data.ProductId;
                    record.ProductName = data.ProductName;
                    record.Price = data.Price;
                    record.CategoryUniqueId= data.CategoryUniqueId;
                    await context.SaveChangesAsync();
                    return Ok(record);
                }
                else
                {
                    return NotFound("Record you are trying to update is not found");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
                var record = await context.Products.FindAsync(id);
                if (record != null)
                {
                    context.Products.Remove(record);
                    await context.SaveChangesAsync();
                    return Ok(record);
                }
                else
                {
                    return NotFound("Record you are trying to update is not found");
                }
        }
    }

}
