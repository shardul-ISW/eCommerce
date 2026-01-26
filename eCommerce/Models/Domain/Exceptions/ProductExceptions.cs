using ECommerce.Models.Domain.Entities;

namespace ECommerce.Models.Domain.Exceptions
{
    public sealed class DuplicateSkuException() : DomainException("A product with this SKU already exists") { }
    public sealed class InsufficientStockException(Product p) : DomainException($"{p.Name} has only {p.CountInStock} units in stock") { }
}
