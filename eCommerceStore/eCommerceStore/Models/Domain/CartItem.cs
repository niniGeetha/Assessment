namespace eCommerceStore.Models.Domain
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public float Quantity { get; set; }

        //Navigation properties
        public Item Item { get; set; }
    }
}
