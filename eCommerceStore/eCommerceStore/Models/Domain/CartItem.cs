using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.Domain
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        [Range(1, float.MaxValue)]
        public required float Quantity { get; set; }

        //Navigation properties
        public Item Item { get; set; }
    }
}
