namespace Rentcar.Models.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int UserAccountId { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<VehicleInspection> VehicleInspections { get; set; } = new List<VehicleInspection>();
        public ICollection<AdditionalDriver> AdditionalDrivers { get; set; } = new List<AdditionalDriver>();
        public Branch Branch { get; set; } = null!;
        public ICollection<CarMovement> RequestedCarMovements { get; set; } = new List<CarMovement>();
        public ICollection<CarMovement> ApprovedCarMovements { get; set; } = new List<CarMovement>();
        public ICollection<Charge> Charges { get; set; } = new List<Charge>();
        public ICollection<DriverLicense> DriverLicenses { get; set; } = new List<DriverLicense>();
        public ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
        public UserAccount UserAccount { get; set; } = null!;
    }
}
