namespace ECommerce.Models.Domain.Exceptions
{
    public sealed class InvalidCartItemException() : DomainException("Failed to add to cart. Product ID not present or non-positive count value.");
}
