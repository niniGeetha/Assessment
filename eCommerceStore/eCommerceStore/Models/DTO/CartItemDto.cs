using eCommerceStore.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.DTO
{
    public class CartItemDto
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        //Navigation property
        public Item Item { get; set; }

    }
}
