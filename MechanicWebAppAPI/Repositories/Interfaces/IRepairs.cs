using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Models;


namespace MechanicWebAppAPI.Repositories.Interfaces
{
	public interface IRepairs
	{
		Task<IEnumerable<Repair>> Get();

		Task<Repair> Get(Guid Repair_id);

		Task<Repair> Create(Repair repair);

		Task Update(Repair repair);

		Task Delete(Guid Repair_id);
	}
}
