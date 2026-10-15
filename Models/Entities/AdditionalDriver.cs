using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class AdditionalDriver
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Surname { get; set; } = string.Empty;
        [StringLength(100)]
        public string? Patronymic { get; set; }
        [Required]
        [StringLength(50)]
        public string DriverLicenseNumber { get; set; } = string.Empty;
        public VerificationStatus Status { get; set; } = VerificationStatus.WaitingForVerification;
        public int BookingId { get; set; }
        [Required]
        [StringLength(16)]
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int? ManagerId { get; set; }
        [StringLength(1000)]
        public string? RejectionReason { get; set; }
        public DateTime? VerificationDate { get; set; }
        public Booking Booking { get; set; } = null!;
        public Manager? Manager { get; set; }
    }
}
