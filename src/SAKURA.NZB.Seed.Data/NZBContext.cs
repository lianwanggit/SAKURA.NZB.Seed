using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SAKURA.NZB.Seed.Domain;

namespace SAKURA.NZB.Seed.Data
{
	public class NZBContext : DbContext
    {
		public DbSet<Category> Categories { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ExchangeRate> ExchangeRates { get; set; }
		public DbSet<ExchangeRecord> ExchangeRecords { get; set; }
		public DbSet<Shipment> Shipments { get; set; }

		public DbSet<Configuration> Configs { get; set; }

		public NZBContext()
		{
		}

		public NZBContext(DbContextOptions<NZBContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ForSqlServerUseIdentityColumns();

			modelBuilder.Entity<OrderProduct>()
				.HasOne(x => x.Product)
				.WithOne()
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(modelBuilder);
		}

	}
}
