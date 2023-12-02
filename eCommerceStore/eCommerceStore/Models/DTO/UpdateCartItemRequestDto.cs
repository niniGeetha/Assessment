using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.DTO
{
    public class UpdateCartItemRequestDto
    {
        [Required]
        [MinLength(1)]
        public int ItemId { get; set; } = 1;

        [Required]
        [Range(1, float.MaxValue)]
        public float Quantity { get; set; } = 1;

    }
}
