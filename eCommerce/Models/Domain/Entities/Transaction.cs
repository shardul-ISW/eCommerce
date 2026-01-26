using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Models.Domain.Entities
{
    public enum TransactionStatus
    {
        Success, Failed, Processing, Rollback
    }
    public class Transaction : Entity
    {
        public decimal? Amount { get; set; }

        public TransactionStatus? Status { get; set; }
    }

    public class TransactionConfiguration : EntityConfiguration<Transaction>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Transaction> builder)
        {
            //Field: Amount Constraint: REQUIRED
            builder.Property(transaction => transaction.Amount).IsRequired();

            //Store Status as a string (preventing default conversion to integer)
            builder.Property(transaction => transaction.Status).HasConversion<string>().IsRequired();
        }
    }

}
