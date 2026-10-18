using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class AdditionalDriver
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DriverLicenseId { get; set; }
        public VerificationStatus Status { get; set; } = VerificationStatus.WaitingForVerification;
        public int BookingId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ManagerId { get; set; }
        [StringLength(1000)]
        public string? RejectionReason { get; set; }
        public DateTime? VerificationDate { get; set; }
        public Booking Booking { get; set; } = null!;
        public Manager? Manager { get; set; }
        public Person Person { get; set; } = null!;
        public DriverLicense DriverLicense { get; set; } = null!;
    }
}
