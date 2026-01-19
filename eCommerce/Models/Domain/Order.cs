using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Domain
{   

    public enum OrderStatus
    {
        Delivered, WaitingForSellerToAccept, InTransit, AwaitingPayment, Cancelled
    }
    public class Order
    {
        public required Guid Id { get; set; } = Guid.CreateVersion7();

        public required Product Product { get; set; }

        public required Buyer Buyer { get; set; }

        public required Seller Seller { get; set; }

        public required int Count { get; set; }

        public required string Address { get; set; }

        public required Transaction Transaction { get; set; }

        public required OrderStatus Status { get; set; }
    }
}
