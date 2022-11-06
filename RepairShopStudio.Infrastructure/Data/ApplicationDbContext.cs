using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models;
using RepairShopStudio.Infrastructure.Data.Models.Account;

namespace RepairShopStudio.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ShopService> ShopServices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleComponent> VehicleComponents { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OperatingCard> OperatingCards { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SupplierSparePart>()
                .HasKey(x => new { x.SupplierId, x.PartId });

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
