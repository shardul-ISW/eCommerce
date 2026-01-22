using ECommerce.Models.Domain;

namespace ECommerce.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrdersAsync(
            IReadOnlyCollection<Guid>? orderIds = null,
            IReadOnlyCollection<Guid>? sellerIds = null,
            IReadOnlyCollection<Guid>? productIds = null
            );
    }
}
