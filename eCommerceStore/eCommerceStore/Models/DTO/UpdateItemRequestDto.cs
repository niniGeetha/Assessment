using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.DTO
{
    public class UpdateItemRequestDto
    {
        [Required]
        public int Id { get; set; } 

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1, float.MaxValue)]
        public required float Price { get; set; } = 1;
    }
}
