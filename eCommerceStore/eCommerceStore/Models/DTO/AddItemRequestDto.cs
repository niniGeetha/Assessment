using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.DTO
{
    public class AddItemRequestDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1, float.MaxValue)]
        public float Price { get; set; }
    }
}
