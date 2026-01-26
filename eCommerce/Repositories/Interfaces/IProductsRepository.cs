using ECommerce.Models.Domain.Entities;

namespace ECommerce.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProductsAsync(
            IReadOnlyCollection<Guid> sellerIds,
            IReadOnlyCollection<Guid>? productIds = null
            );

        Task CreateProductAsync(Product product);

        Task SaveChangesAsync();
    }
}
