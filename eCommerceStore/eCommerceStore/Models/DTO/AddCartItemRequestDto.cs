using eCommerceStore.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.DTO
{
    public class AddCartItemRequestDto
    {
        [Required]
        [MinLength(1)]
        public int  ItemId { get; set; }

        [Required]
        [Range(1, float.MaxValue)]
        public float Quantity { get; set; }
    }
}
