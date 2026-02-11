namespace ECommerce.Models.DTO.Auth.Request
{
    public class SellerRegisterRequestDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string BankAccountNumber { get; set; }
    }
}
