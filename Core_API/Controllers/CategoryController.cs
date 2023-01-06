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
    public class CategoryController : ControllerBase
    {
        NitorShopDbContext context;

        public CategoryController(NitorShopDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var record = await context.Categories.ToListAsync();
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
            var record = await context.Categories.FindAsync(id);
            return Ok(record);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Category data)
        {
            if (ModelState.IsValid)
            {
                var cat =  (await context.Categories.ToListAsync()).Where(c => c.CategoryId.Trim() == data.CategoryId.Trim()).FirstOrDefault();
                if (cat != null)
                    throw new Exception($"CatedoryId : {data.CategoryId} is already exist");

                var record = await context.Categories.AddAsync(data);
                await context.SaveChangesAsync();
                return Ok(record.Entity);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category data)
        {
            if (ModelState.IsValid)
            {
                var record = await context.Categories.FindAsync(id);
                if (record != null)
                {
                    record.CategoryId = data.CategoryId;
                    record.CategoryName = data.CategoryName;
                    record.BasePrice = data.BasePrice;
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
           
                var record = await context.Categories.FindAsync(id);
                if (record != null)
                {
                    context.Categories.Remove(record);
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
