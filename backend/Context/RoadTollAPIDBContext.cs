using Microsoft.EntityFrameworkCore;
using RoadTollAPI.Entities;


namespace RoadTollAPI.Context
{
    public class RoadTollAPIDBContext : DbContext
    {
        public RoadTollAPIDBContext(DbContextOptions<RoadTollAPIDBContext> options) : base(options)
        {
        }

        // All entities need to be "listed" here or the Entity Framework don't "know" about them
        public DbSet<Owner> Owners { set; get; }
        public DbSet<Car> Cars { set; get; }
        public DbSet<Toll> Tolls { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the relationship using Fluent API

            // Car and Owner one-to-one relationship
            modelBuilder.Entity<Owner>()
                .HasOne<Car>(o => o.car)
                .WithOne(c => c.owner)
                .HasForeignKey<Car>(c => c.CarOfOwnerId);

            // Toll and Car one-to-many relationship
            modelBuilder.Entity<Toll>()
            .HasOne<Car>(t => t.car)
            .WithMany(c => c.tolls)
            .HasForeignKey(t => t.currentCarId);
        }
    }
}
