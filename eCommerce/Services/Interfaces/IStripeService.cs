using ECommerce.Models.Domain.Entities;

namespace ECommerce.Services.Interfaces
{
    public interface IStripeService
    {
        /// <summary>
        /// Creates a Stripe Checkout Session for the given transaction and cart items.
        /// Returns the checkout URL for the buyer to complete payment.
        /// Also stores the Stripe Session ID on the transaction.
        /// </summary>
        Task<string> CreateCheckoutSessionAsync(Transaction transaction, List<CartItem> cartItems);
    }
}
