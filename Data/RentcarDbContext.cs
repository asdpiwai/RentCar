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
                .HasForeignKey(b => b.ReceivingBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.ReturnBranch)
                .WithMany(branch => branch.ReturnBookings)
                .HasForeignKey(b => b.ReturnBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.FromBranch)
                .WithMany(branch => branch.FromCarMovements)
                .HasForeignKey(cm => cm.FromBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.ToBranch)
                .WithMany(branch => branch.ToCarMovements)
                .HasForeignKey(cm => cm.ToBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.RequestedManager)
                .WithMany(m => m.RequestedCarMovements)
                .HasForeignKey(cm => cm.RequestedManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.ApprovedManager)
                .WithMany(m => m.ApprovedCarMovements)
                .HasForeignKey(cm => cm.ApprovedManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdditionalDriver>()
                .HasOne(ad => ad.Booking)
                .WithOne(b => b.AdditionalDriver)
                .HasForeignKey<AdditionalDriver>(ad => ad.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Charge>()
                .HasOne(c => c.Booking)
                .WithMany(b => b.Charges)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleInspection>()
                .HasOne(vi => vi.Booking)
                .WithMany(b => b.VehicleInspections)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Car)
                .WithMany(c => c.Bookings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarMovement>()
                .HasOne(cm => cm.Car)
                .WithMany(c => c.CarMovements)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleInspection>()
                .HasOne(vi => vi.Car)
                .WithMany(c => c.VehicleInspections)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Maintenance>()
                .HasOne(m => m.Car)
                .WithMany(c => c.Maintenances)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleDamage>()
                .HasOne(vd => vd.VehicleInspection)
                .WithMany(vi => vi.VehicleDamages)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Charge)
                .WithMany(c => c.Payments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DriverLicense>()
                .HasOne(dl => dl.Customer)
                .WithMany(c => c.DriverLicenses)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DriverLicense>()
                .HasOne(dl => dl.Manager)
                .WithMany(m => m.DriverLicenses)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdditionalDriver>()
                .HasOne(ad => ad.Manager)
                .WithMany(m => m.AdditionalDrivers)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Maintenance>()
                .HasOne(m => m.VehicleInspection)
                .WithMany(vi => vi.Maintenances)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Manager>()
                .HasOne(m => m.Branch)
                .WithMany(branch => branch.Managers)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Charge>()
                .HasOne(c => c.Manager)
                .WithMany(m => m.Charges)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Maintenance>()
                .HasOne(m => m.Manager)
                .WithMany(man => man.Maintenances)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Manager)
                .WithMany(m => m.Bookings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Branch)
                .WithMany(branch => branch.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleInspection>()
                .HasOne(vi => vi.Manager)
                .WithMany(m => m.VehicleInspections)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
