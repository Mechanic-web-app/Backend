using MechanicWebAppAPI.Api.Responses.Wrappers;
using MechanicWebAppAPI.Common.Requests.CarRequests;
using MechanicWebAppAPI.Core.Dtos.Car;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<CarDto>> GetCars()
        {
            return await _carRepository.Get();
        }
        [HttpGet("{Car_id}")]
        public async Task<ActionResult<Car>> Get(Guid Car_id)
        {
            return await _carRepository.Get(Car_id);
        }
        [HttpGet("byUser/{Car_user_id}")]
        public async Task<IEnumerable<CarDto>> GetByUser(Guid Car_user_id)
        {
            return await _carRepository.GetByUser(Car_user_id);
        }
        [HttpPost]
        public async Task<ActionResult<CarDto>> PostCars([FromBody] CarAddRequest car)
        { 
            return await _carRepository.Create(car);
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

        [HttpDelete("{Car_id}")]
        public async Task<bool> Delete(Guid Car_id)
        {
            var carToDelete = await _carRepository.Get(Car_id);
            if (carToDelete == null)
                return false;

            await _carRepository.Delete(carToDelete.Car_id);
            return true;
        }
    }
}

