namespace ECommerce.Models.Domain
{
    public abstract class AbstractUser
    {   
        public Guid Id { get; private set; } = Guid.CreateVersion7();
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required  string Password_Hash { get; set; }

    }
}
