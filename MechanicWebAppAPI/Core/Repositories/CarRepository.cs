using AutoMapper;
using MechanicWebAppAPI.Common.Requests.CarRequests;
using MechanicWebAppAPI.Core.Dtos.Car;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Repositories
{
    public class CarRepository : BaseRepository, ICars
    {

        public CarRepository(AppDbContext context,IMapper mapper) : base(context,mapper)
        {
        }

        public async Task<CarDto> Create(CarAddRequest car)
        {
            var carDto = _mapper.Map<CarAddRequest, Car>(car);
            carDto.Car_id = Guid.NewGuid();
            carDto.Car_user_id = Guid.Parse(car.Car_user_id);
            _context.Cars.Add(carDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<Car, CarDto>(carDto);
        }

        public async Task<bool> Delete(Guid Car_id)
        {
            var carToDelete = await _context.Cars.FindAsync(Car_id);
            _context.Cars.Remove(carToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CarDto>> Get()
        {
            return await _context.Cars.Select(car => _mapper.Map<Car, CarDto>(car)).ToListAsync();
        }
        public async Task<Car> Get(Guid Car_id)
        {
            return await _context.Cars.FindAsync(Car_id);
        }

        public async Task<IEnumerable<CarDto>> GetByUser(Guid Car_user_id)
        {
            return await _context.Cars.Where(x => x.Car_user_id == Car_user_id).Select(car => _mapper.Map<Car, CarDto>(car)).ToListAsync();
        }

        public async Task Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
