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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.ReceivingBranch)
                .WithMany(branch => branch.ReceivingBookings)
                .HasForeignKey(b => b.ReceivingBranchId);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.ReturnBranch)
                .WithMany(branch => branch.ReturnBookings)
                .HasForeignKey(b => b.ReturnBranchId);
            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.FromBranch)
                .WithMany(branch => branch.FromCarMovements)
                .HasForeignKey(cm => cm.FromBranchId);
            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.ToBranch)
                .WithMany(branch => branch.ToCarMovements)
                .HasForeignKey(cm => cm.ToBranchId);
            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.RequestedManager)
                .WithMany(m => m.RequestedCarMovements)
                .HasForeignKey(cm => cm.RequestedManagerId);
            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.ApprovedManager)
                .WithMany(m => m.ApprovedCarMovements)
                .HasForeignKey(cm => cm.ApprovedManagerId);
            modelBuilder.Entity<AdditionalDriver>()
                .HasOne(ad => ad.Booking)
                .WithOne(b => b.AdditionalDriver)
                .HasForeignKey<AdditionalDriver>(ad => ad.BookingId);
        }
    }
}
