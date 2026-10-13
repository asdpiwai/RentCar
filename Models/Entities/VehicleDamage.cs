using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class VehicleDamage
    {
        public int Id { get; set; }
        public int VehicleInspectionId { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        public DamageSeverity Severity {  get; set; }
    }
}
