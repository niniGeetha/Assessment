using eCommerceStore.Models.Data;
using eCommerceStore.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStore.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ECommerceDbContext dbContext;

        public ItemRepository(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Item> CreateItemAsync(Item item)
        {
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();
            return item;            
        }

        public async Task<Item> DeleteItemAsync(int id)
        {
            var item = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == id);
            if (item is null)
                return null;
            dbContext.Items.Remove(item);
            await dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            var items = await dbContext.Items.ToListAsync();
            return items;
            
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            var item = await dbContext.Items.SingleOrDefaultAsync(x=>x.Id == id);
            return item;
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            var existingItem = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == item.Id);
            if(existingItem is null)
            {
                return null;
            }
            existingItem.Title = item.Title;
            existingItem.Price = item.Price;

            await dbContext.SaveChangesAsync();
            return existingItem;

        }
    }
}
