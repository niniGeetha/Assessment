using eCommerceStore.Models.Domain;

namespace eCommerceStore.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<CartItem> AddItemsToCartAsync(CartItem cartItem);

        Task<List<CartItem>> GetAllItemsFromCartAsync();

        Task<CartItem> UpdateCartAsync(CartItem cartItem);
    }
}
