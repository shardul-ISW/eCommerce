namespace ECommerce.Models.Domain
{
    public class Cart
    {
        public required Buyer Buyer { get; set; }
        public required Product Product { get; set; }
        public required int Count { get; set; }
    }
}
