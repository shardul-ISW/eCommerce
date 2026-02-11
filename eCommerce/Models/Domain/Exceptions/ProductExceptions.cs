using ECommerce.Models.Domain.Entities;

namespace ECommerce.Models.Domain.Exceptions
{
    public sealed class DuplicateSkuException()
        : DomainException("A product with this SKU already exists.", StatusCodes.Status409Conflict)
    { }

    public sealed class InsufficientStockException(Product p)
        : DomainException($"{p.Name} has only {p.AvailableStock} units in stock", StatusCodes.Status422UnprocessableEntity)
    { }

    public sealed class ProductNotFoundException(Guid productId)
        : DomainException($"Product {productId} not found.", StatusCodes.Status404NotFound)
    { }

}
