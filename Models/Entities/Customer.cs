namespace Rentcar.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname {  get; set; } = string.Empty;
        public string? Patronymic {  get; set; }
        public string Email { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsBlocked { get; set; }
        public string? BlockReason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
