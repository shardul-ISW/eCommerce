using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Models.Domain
{
    public class Cart : Entity
    {
        public Guid BuyerId { get; set; }
        public Buyer Buyer { get; set; } = null!;

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        private Cart() { }

        internal Cart(Buyer buyer)
        {
            Buyer = buyer;
        }
    }

    public class CartConfiguration : EntityConfiguration<Cart>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Cart> builder)
        {
            //Field: BuyerId Constraint: FOREIGN KEY and UNIQUE
            builder.HasOne(c => c.Buyer).WithOne(b => b.Cart).HasForeignKey<Cart>(c => c.BuyerId).IsRequired();
            builder.HasIndex(c => c.BuyerId).IsUnique();
        }
    }

}
