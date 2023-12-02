using eCommerceStore.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.DTO
{
    public class AddCartItemRequestDto
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int  ItemId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }
    }
}
