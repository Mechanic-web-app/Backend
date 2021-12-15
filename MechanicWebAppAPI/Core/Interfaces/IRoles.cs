using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Data.Models;


namespace MechanicWebAppAPI.Core.Interfaces
{
	public interface IRoles
	{
		Task<IEnumerable<Role>> Get();

		Task<Role> Get(Guid Role_id);

		Task<Role> Create(Role role);

		Task Update(Role role);

		Task Delete(Guid Role_id);
	}
}
