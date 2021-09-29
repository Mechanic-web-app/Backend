using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Data;
using MechanicWebAppAPI.Models;
using MechanicWebAppAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MechanicWebAppAPI.Repositories
{
    public class CarRepository : ICars
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task Delete(Guid Car_id)
        {
            var carToDelete = await _context.Cars.FindAsync(Car_id);
            _context.Cars.Remove(carToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> Get()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> Get(Guid Car_id)
        {
            return await _context.Cars.FindAsync(Car_id);
        }

        public async Task Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
