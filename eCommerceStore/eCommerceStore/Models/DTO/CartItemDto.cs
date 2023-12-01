using eCommerceStore.Models.Domain;

namespace eCommerceStore.Models.DTO
{
    public class CartItemDto
    {  
        public float Quantity { get; set; }

        //Navigation property
        public Item Item { get; set; }

    }
}
