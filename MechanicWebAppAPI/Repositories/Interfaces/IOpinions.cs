using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Models;


namespace MechanicWebAppAPI.Repositories.Interfaces
{
	public interface IOpinions
	{
		Task<IEnumerable<Opinion>> Get();

		Task<Opinion> Get(Guid Opinion_id);

		Task<Opinion> Create(Opinion opinion);

		Task Update(Opinion opinion);

		Task Delete(Guid Opinion_id);
	}
}
