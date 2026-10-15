using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class VehicleInspection
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int BookingId { get; set; }
        public int ManagerId { get; set; }
        public int Mileage {  get; set; }
        public int FuelLevel {  get; set; }
        public DateTime CreatedAt { get; set; }
        public VehicleInspectionType Type { get; set; }
        public Car Car { get; set; } = null!;
        public Booking Booking { get; set; } = null!;
        public Manager Manager { get; set; } = null!;
        public ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
        public ICollection<VehicleDamage> VehicleDamages { get; set;} = new List<VehicleDamage>();
    }
}
