using eCommerceStore.Models.Data;
using eCommerceStore.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ECommerceDbContext dbContext;

        public ItemsController(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetItems() {

            var items =  await dbContext.Items.ToListAsync();
            return Ok(items);

        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItems(Item item)
        {
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]        
        public async Task<IActionResult> UpdateItem(Item item)
        {
            var existingItem = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            if(existingItem == null)
            {
                return NotFound();
            }
            existingItem.Title = item.Title;
            existingItem.Price = item.Price;
            await dbContext.SaveChangesAsync();
            return Ok(existingItem);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var existingItem = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(existingItem == null)
            {
                return NotFound();
            }
            dbContext.Items.Remove(existingItem);
            await dbContext.SaveChangesAsync();
            return Ok();

        }


    }
}
