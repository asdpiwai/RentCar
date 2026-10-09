using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class DriverLicense
    {
        public int Id { get; set; }
        public string DriverLicenseNumber { get; set; } = string.Empty;
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public VerificationStatus Status { get; set; }
        public DateTime? VerificationDate { get; set; }
        public int? ManagerId{ get; set; }
        public string? RejectionReason { get; set; }
    }
}
