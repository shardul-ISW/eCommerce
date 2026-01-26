using ECommerce.Models.Domain.Entities;

namespace ECommerce.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransactionForCartItems(List<CartItem> cartItems);
    }
}
