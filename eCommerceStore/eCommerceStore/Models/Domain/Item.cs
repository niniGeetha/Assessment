using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.Domain
{
    public class Item
    {
        public int Id { get; set; }      
        
        public required string Title { get; set; }

        [Range(1, float.MaxValue)]
        public required float Price { get; set; }
    }
}
