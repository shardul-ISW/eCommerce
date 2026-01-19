using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models.Domain
{   
    internal class BuyerContext : DbContext
    {
        public DbSet<Buyer> Buyer { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>().Property(b => b.Id).IsRequired();
        }
        #endregion
    }
    public class Buyer : AbstractUser
    {
        public required string Address { get; set; }
    }

    
}
