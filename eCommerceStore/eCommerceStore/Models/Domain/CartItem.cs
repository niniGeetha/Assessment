namespace eCommerceStore.Models.Domain
{
    public class CartItem
    {
        public int Id { get; set; }
        public required Item Item { get; set; }
        public required float Quantity { get; set; }
    }
}
