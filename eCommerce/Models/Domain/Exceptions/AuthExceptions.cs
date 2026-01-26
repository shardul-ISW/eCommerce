namespace ECommerce.Models.Domain.Exceptions
{
    public sealed class DuplicateEmailException() : DomainException("This email address is already registered.");
}
