using Microsoft.EntityFrameworkCore;
using RoadTollAPI.Entities;


namespace RoadTollAPI.Context
{
    public class RoadTollAPIDBContext : DbContext
    {
        // All entities need to be "listed" here or the Entity Framework don't "know" about them
        public DbSet<Owner> Owners { set; get; }
        public DbSet<Car> Cars { set; get; }
        public DbSet<Day> Days { set; get; }
        public DbSet<DayCar> DayCars { set; get; }

        public RoadTollAPIDBContext(DbContextOptions<RoadTollAPIDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the relationship using Fluent API

            // Configuring the one-to-one relationship between tables Car and Owner
            modelBuilder.Entity<Owner>()
                .HasOne<Car>(o => o.car)
                .WithOne(c => c.owner)
                .HasForeignKey<Car>(c => c.CarOfOwnerId);

            // Composite Primary Key for joining the tables Car and Day with a many-to-many relationship
            modelBuilder.Entity<DayCar>().HasKey(sc => new { sc.dayId, sc.carId });
        }
    }
}
