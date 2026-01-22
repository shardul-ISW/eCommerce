using ECommerce.Models.Domain;

namespace ECommerce.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProductsAsync(
            IReadOnlyCollection<Guid>? sellerIds = null,
            IReadOnlyCollection<Guid>? productIds = null
            );
    }
}
