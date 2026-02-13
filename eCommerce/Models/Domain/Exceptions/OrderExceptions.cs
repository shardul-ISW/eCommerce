using ECommerce.Models.Domain.Entities;

namespace ECommerce.Models.Domain.Exceptions
{
    public sealed class InvalidOrderStatusTransitionException(OrderStatus current, OrderStatus requested)
        : DomainException(
            $"Cannot transition order from {current} to {requested}.",
            StatusCodes.Status422UnprocessableEntity)
    { }
}
