using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int? BranchId { get; set; }
        public int Mileage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public LocationType LocationType { get; set; }
        public CarStatus Status { get; set; }
    }
}
