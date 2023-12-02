using eCommerceStore.Models.Data;
using eCommerceStore.Models.Domain;
using eCommerceStore.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStore.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ECommerceDbContext dbContext;

        public ShoppingCartRepository(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<CartItem> AddItemsToCartAsync(CartItem cartItem)
        {
            await dbContext.CartItems.AddAsync(cartItem);
            await dbContext.SaveChangesAsync();
            return cartItem;
        }

        public async Task<List<CartItem>> GetAllItemsFromCartAsync()
        {
            var itemsFromCart = await dbContext.CartItems.Include("Item").ToListAsync();
            return itemsFromCart;
        }

        public async Task<CartItem> UpdateCartAsync(CartItem cartItem)
        {
            var existingCartItem =  await dbContext.CartItems.SingleOrDefaultAsync(x=>x.ItemId== cartItem.ItemId);
            if (existingCartItem == null)
                return null;                
            
            existingCartItem.Quantity = cartItem.Quantity;
            await dbContext.SaveChangesAsync();
            return cartItem;
        }
    }
}
