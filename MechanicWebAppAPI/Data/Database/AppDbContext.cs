using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MechanicWebAppAPI.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasMany(p => p.Cars)
               .WithOne(b => b.User)
               .HasForeignKey(p => p.Car_user_id)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasOne(s => s.Opinion)
                .WithOne(p => p.User)
                .HasForeignKey<Opinion>(s => s.Opinion_user_id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Car>()
               .HasMany(p => p.Repairs)
               .WithOne(b => b.Car)
               .HasForeignKey(p => p.Repaired_car_id)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Opinion>()
                .HasIndex(p => p.Opinion_user_id)
                .IsUnique();

        }
    }
}
