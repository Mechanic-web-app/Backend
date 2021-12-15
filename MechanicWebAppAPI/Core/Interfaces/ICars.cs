using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Data.Models;


namespace MechanicWebAppAPI.Core.Interfaces
{
	public interface ICars
	{
		Task<IEnumerable<Car>> Get();

		Task<Car> Get(Guid Car_id);

		Task<Car> Create(Car car);

		Task Update(Car car);

		Task Delete(Guid Car_id);
	}
}
