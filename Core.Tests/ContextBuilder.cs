using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core.Tests
{
    public class ContextBuilder
    {
        private readonly DbContextOptionsBuilder<AppDbContext> builder;
        private readonly DbContextOptions<AppDbContext> options;

        public AppDbContext Context { get; }

        public ContextBuilder()
        {

        builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase", new InMemoryDatabaseRoot());
            builder.EnableServiceProviderCaching(false);
            builder.EnableSensitiveDataLogging(true);
            options = builder.Options;
            Context = new AppDbContext(options);
            FetchDatabase();
        }
        public async void FetchDatabase()
        {
            var user = await Context.Users.AddAsync(new User()
            {
                Email = "example@example.com",
                Password = "AQAAAAEAACcQAAAAEDlYSTL / d9xskfzumPYbyO4emO9MLv2RY8pZADwANh5QUCHjTcn0NsfwycICXlIs5g == ",
                User_confirmed = true,
                Name ="Example",
                Lastname = "Example",
                Role = "Employee",
                Phone_number = "123456789",
            }).ConfigureAwait(false);

            var company = await Context.Cars.AddAsync(new Car()
            {
                Car_brand = "Example",
                Car_model = "Example",
                Car_reg_number = "Example",
                Car_user_id = user.Entity.User_id
            }).ConfigureAwait(false);

            await Context.Repairs.AddAsync(new Repair()
            {
                Repair_description = "EXAMPLE",
                Repair_cost = 100,
                Repair_date = "EXAMPLE",
                Repaired_car_id = Context.Cars.FirstOrDefault(i => i.Car_id != Guid.Empty)?.Car_id ?? Guid.Empty
            }).ConfigureAwait(false);

            await Context.Opinions.AddAsync(new Opinion()
            {
                Opinion_description ="Example",
                Opinion_rate = 5,
                Opinion_user_id = user.Entity.User_id,
                Opinion_user_name = user.Entity.Name,
                Opinion_user_lastname = user.Entity.Lastname,
            }).ConfigureAwait(false);
            await Context.Messages.AddAsync(new Message()
            {
                MessageSender = user.Entity.User_id,
                UserName = "Example",
                UserLastname = "Example",
                MessageContext = "Example",
                MessageTime = DateTime.Now,
                MessageReceiver = user.Entity.User_id,
                Room_id = user.Entity.User_id,
            }).ConfigureAwait(false);
            await Context.ChatRooms.AddAsync(new ChatRoom()
            {
                Room_id = Guid.NewGuid(),
                RoomName = "Example"
            }).ConfigureAwait(false);
            Context.Entry(new ChatRoom()).State = EntityState.Detached;
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

