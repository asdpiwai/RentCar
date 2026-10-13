using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class CarMovement
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FromBranchId { get; set; }
        public int ToBranchId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RequestedManagerId { get; set; }
        public int? ApprovedManagerId { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public MovementStatus Status { get; set; } = MovementStatus.Pending;
    }
}
