using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int ReceivingBranchId { get; set; }
        public int ReturnBranchId { get; set; }
        public DateTime RentalStart {  get; set; }
        public DateTime RentalEnd { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal BookingPricePerDay { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        public DateTime CreatedAt { get; set; }
        public Customer Customer { get; set; } = null!;
        public Car Car { get; set; } = null!;
        public AdditionalDriver? AdditionalDriver { get; set; }
    }
}
