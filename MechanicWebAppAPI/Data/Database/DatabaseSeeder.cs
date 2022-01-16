using MechanicWebAppAPI.Data.Models;
using MechanicWebAppAPI.Data.Roles;
using System;
using System.Linq;

namespace MechanicWebAppAPI.Data.Database
{
    public class DatabaseSeeder
    {
        public static void SeedData(AppDbContext context)
        {
            SeedUser(context);
        }

        public static void SeedUser(AppDbContext context)
        {
            if (context.Users.Count() == 0)
            {
                var user = context.Users.Add(new User()
                {
                    Email = "admin@mechanicapp.com",
                    Role = Role.Admin,
                    Password = "AQAAAAEAACcQAAAAEI + PjxFUCPXyZnkOatVFZASGSFQNc6sjHScYEQIW9aF5m8sqw2 + J1wDXYtBMmyEaJA ==",
                    Name= "Admin",
                    Lastname= "Admin",
                    User_confirmed = true,
                    Token = Guid.Empty,
                    Phone_number = "123456789"

                });
                var user2 = context.Users.Add(new User()
                {
                    Email = "Employee@mechanicapp.com",
                    Role = Role.Employee,
                    Password = "AQAAAAEAACcQAAAAEPc/EMiR9I4yKrR1x5Qk3mMxgvaBfxK3z5l56qC0+hohIo2q1oG+MCs4EpIBMzLtwg==",
                    Name = "Employee",
                    Lastname = "Employee",
                    User_confirmed = true,
                    Token = Guid.Empty,
                    Phone_number = "123456789"
                });
                var user3 = context.Users.Add(new User()
                {
                    Email = "Testuser@mechanicapp.com",
                    Role = Role.User,
                    Password = "AQAAAAEAACcQAAAAEHozHzgpsEoJi1H0xJt2lhh+R9550R6HAvUk5G6gY5MloV/IKsT1dlziD/9nAwv6Xw==",
                    Name = "Test",
                    Lastname = "User",
                    User_confirmed = true,
                    Token = Guid.Empty,
                    Phone_number = "123456789"
                });
                context.SaveChangesAsync().Wait();
            }
        }
    }
}