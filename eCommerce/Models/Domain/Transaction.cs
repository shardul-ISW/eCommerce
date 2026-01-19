namespace ECommerce.Models.Domain
{
    public enum TransactionStatus
    {
        Success, Failed, Processing
    }
    public class Transaction
    {
        public required Guid Id { get; set; } = Guid.CreateVersion7();

        public required Seller Seller { get; set; }

        public required float Amount { get; set; }

        public required TransactionStatus Status { get; set; }
    }
}
