using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ManagerId { get; set; }
        public int? VehicleInspectionId { get; set; }
        public int Mileage { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public MaintenanceStatus Status { get; set; } = MaintenanceStatus.Planned;
        public MaintenanceType Type { get; set; }
        public Car Car { get; set; } = null!;
        public Manager Manager { get; set; } = null!;
        public VehicleInspection? VehicleInspection { get; set; }
    }
}
