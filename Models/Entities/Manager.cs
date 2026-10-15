using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Manager
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
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [StringLength(16)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(1000)]
        public string PasswordHash { get; set; } = string.Empty;
        public int BranchId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<VehicleInspection> VehicleInspections { get; set; } = new List<VehicleInspection>();
        public ICollection<AdditionalDriver> AdditionalDrivers { get; set; } = new List<AdditionalDriver>();
        public Branch Branch { get; set; } = null!;
        public ICollection<CarMovement> RequestedCarMovements { get; set; } = new List<CarMovement>();
        public ICollection<CarMovement> ApprovedCarMovements { get; set; } = new List<CarMovement>();
        public ICollection<Charge> Charges { get; set; } = new List<Charge>();
        public ICollection<DriverLicense> DriverLicenses { get; set; } = new List<DriverLicense>();
        public ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
    }
}
