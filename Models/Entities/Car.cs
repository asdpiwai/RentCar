using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Brand { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        [Required]
        [StringLength(10)]
        public string LicensePlate { get; set; } = string.Empty;
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int? BranchId { get; set; }
        public int Mileage { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public LocationType LocationType { get; set; } = LocationType.InBranch;
        public CarStatus Status { get; set; } = CarStatus.Inspection;
        public Category Category { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
