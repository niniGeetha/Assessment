using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.DTO
{
    public class UpdateCartItemRequestDto
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ItemId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

    }
}
