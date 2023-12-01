using eCommerceStore.Models.Domain;

namespace eCommerceStore.Models.DTO
{
    public class AddCartItemRequestDto
    {
        public int  ItemId { get; set; }
        
        public int Quantity { get; set; }
    }
}
