using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Models.Domain.Entities
{   
    public class Buyer : Entity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Address { get; set; } = null!;
        public Cart Cart { get; private set; } = null!;

        private Buyer() { }

        public static Buyer Create(string name, string email, string passwordHash, string address)
        {
            var buyer = new Buyer { Name = name , Email = email, PasswordHash = passwordHash, Address = address };
            buyer.Cart = new Cart(buyer);
            return buyer;
        }
    }

    public class BuyerConfiguration : EntityConfiguration<Buyer>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Buyer> builder)
        {   
            // Field: Email, Constraint: UNIQUE and Required
            builder.HasIndex(buyer => buyer.Email).IsUnique();
            builder.Property(buyer => buyer.Email).IsRequired();

            // Fields: Username, Address, Password_Hash Constraint: Required
            builder.Property(buyer => buyer.Name).IsRequired();
            builder.Property(buyer => buyer.Address).IsRequired();
            builder.Property(buyer => buyer.PasswordHash).IsRequired();
        }
    }

}
