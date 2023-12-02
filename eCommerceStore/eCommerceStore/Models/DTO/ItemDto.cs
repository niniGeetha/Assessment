using System.ComponentModel.DataAnnotations;

namespace eCommerceStore.Models.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1, float.MaxValue)]
        public float Price { get; set; }
    }
}
