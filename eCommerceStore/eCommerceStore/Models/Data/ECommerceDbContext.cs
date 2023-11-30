using eCommerceStore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStore.Models.Data
{
    public class ECommerceDbContext: DbContext
    {
        public ECommerceDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


    }
}
