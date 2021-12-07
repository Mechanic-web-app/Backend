﻿using Microsoft.EntityFrameworkCore;
using MechanicWebAppAPI.Models;

namespace MechanicWebAppAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<User> Users { get; set;}

		public DbSet<Car> Cars { get; set;}

		public DbSet<Repair> Repairs { get; set; }
		
		public DbSet<Role> Roles { get; set; }
		
		public DbSet<Opinion> Opinions{ get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Car>()
               .HasOne(p => p.User)
               .WithMany()
               .HasForeignKey(p => p.Car_user_id);
			modelBuilder.Entity<Opinion>()
			   .HasOne(p => p.User)
			   .WithMany()
			   .HasForeignKey(p => p.Opinion_user_id);
			modelBuilder.Entity<Repair>()
			   .HasOne(p => p.User)
			   .WithMany()
			   .HasForeignKey(p => p.Repaired_car_user_id);
			modelBuilder.Entity<Repair>()
			   .HasOne(p => p.User)
			   .WithMany()
			   .HasForeignKey(p => p.Repaired_car_user_id);
			modelBuilder.Entity<Repair>()
			   .HasOne(p => p.Car)
			   .WithMany()
			   .HasForeignKey(p => p.Repaired_car_id);
			modelBuilder.Entity<User>()
			   .HasOne(p => p.Role)
			   .WithMany()
			   .HasForeignKey(p => p.User_role);

		}
	}
}