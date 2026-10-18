using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class DriverLicense
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string DriverLicenseNumber { get; set; } = string.Empty;
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int PersonId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public VerificationStatus Status { get; set; } = VerificationStatus.WaitingForVerification;
        public DateTime? VerificationDate { get; set; }
        public int? ManagerId{ get; set; }
        [StringLength(1000)]
        public string? RejectionReason { get; set; }
        public Person Person { get; set; } = null!;
        public Manager? Manager { get; set; }
        public ICollection<AdditionalDriver> AdditionalDrivers { get; set; } = new List<AdditionalDriver>();
    }
}
