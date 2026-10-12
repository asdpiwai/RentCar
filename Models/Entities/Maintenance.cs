using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public MaintenanceStatus Status { get; set; }
        public MaintenanceType Type { get; set; }
    }
}
