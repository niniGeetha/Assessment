namespace eCommerceStore.Models.Domain
{
    public class Item
    {
        public  int Id { get; set; }
        public required string Title { get; set; }
        public required float Price { get; set; }
    }
}
