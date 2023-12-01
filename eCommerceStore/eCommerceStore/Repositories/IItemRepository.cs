using eCommerceStore.Models.Domain;

namespace eCommerceStore.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItemsAsync();

        Task<Item> GetItemByIdAsync(int id);

        Task<Item> CreateItemAsync(Item item);

        Task<Item> UpdateItemAsync(Item item);

        Task<Item> DeleteItemAsync(int id);
    }
}
