using Microsoft.EntityFrameworkCore;
using Rentcar.Models.Entities;

namespace Rentcar.Data
{
    public class RentcarDbContext : DbContext 
    {
        public RentcarDbContext(DbContextOptions<RentcarDbContext> options) : base(options) { }
        public DbSet<AdditionalDriver> AdditionalDrivers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarMovement> CarMovements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<VehicleDamage> VehicleDamages { get; set; }
        public DbSet<VehicleInspection> VehicleInspections { get; set; }
    }
}
