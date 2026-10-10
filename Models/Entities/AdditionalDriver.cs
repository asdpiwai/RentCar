using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class AdditionalDriver
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public string DriverLicenseNumber { get; set; } = string.Empty;
        public VerificationStatus Status { get; set; }
        public int BookingId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int? ManagerId { get; set; }
        public string? RejectionReason { get; set; }
        public DateTime? VerificationDate { get; set; }
    }
}
