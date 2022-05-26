using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Set> Sets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>()
                .HasMany(c => c.Foods);
            modelBuilder.Entity<Delivery>()
                .HasMany(c => c.Sets);
            modelBuilder.Entity<Set>()
                .HasMany(c => c.Foods);
        }
    }
}
