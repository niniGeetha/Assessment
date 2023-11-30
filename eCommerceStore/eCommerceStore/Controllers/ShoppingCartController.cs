using eCommerceStore.Models.Data;
using eCommerceStore.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ECommerceDbContext dbContext;

        public ShoppingCartController(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemsToCart(CartItem cartItem)
        {
            await dbContext.CartItems.AddAsync(cartItem);
            await dbContext.SaveChangesAsync();
            return Ok(cartItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartContents()
        {
            var cartContents = await dbContext.CartItems.ToListAsync();
            return Ok(cartContents);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemQuantity(CartItem cartItem)
        {
            var existingCartItem = await dbContext.CartItems.FirstOrDefaultAsync(x => x.Id == cartItem.Id);
            if (existingCartItem == null)
            {
                return NotFound();
            }
            existingCartItem.Quantity = cartItem.Quantity;
            await dbContext.SaveChangesAsync();
            return Ok(existingCartItem);
        }
    }
}
