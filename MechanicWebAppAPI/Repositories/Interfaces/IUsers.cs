using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Models;


namespace MechanicWebAppAPI.Repositories.Interfaces
{
	public interface IUsers
	{
		Task<IEnumerable<User>> Get();

		Task<User> Get(Guid User_id);

		Task<User> Create(User user);

		Task Update(User user);

		Task Delete(Guid User_id);
	}
}
