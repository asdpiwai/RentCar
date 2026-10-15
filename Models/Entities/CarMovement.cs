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
        public Car Car { get; set; } = null!;
        public Branch FromBranch { get; set; } = null!;
        public Branch ToBranch { get; set; } = null!;
        public Manager RequestedManager { get; set; } = null!;
        public Manager? ApprovedManager { get; set; }
    }
}
