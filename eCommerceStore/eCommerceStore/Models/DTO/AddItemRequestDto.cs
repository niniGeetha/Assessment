namespace eCommerceStore.Models.DTO
{
    public class AddItemRequestDto
    {
        public required string Title { get; set; }
        public required float Price { get; set; }
    }
}
