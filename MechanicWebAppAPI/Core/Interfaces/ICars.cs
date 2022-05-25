using MechanicWebAppAPI.Common.Requests.CarRequests;
using MechanicWebAppAPI.Core.Dtos.Car;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface ICars
    {
        Task<IEnumerable<CarDto>> Get();

        Task<Car> Get(Guid Car_id);
        Task<IEnumerable<CarDto>> GetByUser(Guid Car_user_id);

        Task<CarDto> Create(CarAddRequest car);

        Task Update(Car car);

        Task<bool> Delete(Guid Car_id);
    }
}
