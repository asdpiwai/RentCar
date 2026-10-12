using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class VehicleDamage
    {
        public int Id { get; set; }
        public int VehicleInspectionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DamageSeverity Severity {  get; set; }
    }
}
