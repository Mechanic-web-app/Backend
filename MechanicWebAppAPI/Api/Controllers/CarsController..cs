using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Data.Models;
using MechanicWebAppAPI.Core.Repositories;
using MechanicWebAppAPI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MechanicWebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICars _carRepository;

        public CarsController(ICars CarRepository)
        {
            _carRepository = CarRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _carRepository.Get();
        }
        [HttpGet("{Car_id}")]
        public async Task<ActionResult<Car>> GetCars(Guid Car_id)
        {
            return await _carRepository.Get(Car_id);
        }
        [HttpPost]
        public async Task<ActionResult<Car>> PostCars([FromBody] Car car)
        {
            var newCar = await _carRepository.Create(car);
            return CreatedAtAction(nameof(GetCars), new { id = newCar.Car_id }, newCar);
        }

        [HttpPut]
        public async Task<ActionResult> PutCars(Guid Car_id, [FromBody] Car car)
        {
            if (Car_id != car.Car_id)
            {
                return BadRequest();
            }

            await _carRepository.Update(car);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid Car_id)
        {
            var carToDelete = await _carRepository.Get(Car_id);
            if (carToDelete == null)
                return NotFound();

            await _carRepository.Delete(carToDelete.Car_id);
            return NoContent();
        }
    }
}

