using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MechanicWebAppAPI.Repositories.Interfaces
{
	public interface IUsers
	{

		Task<User> Get(Guid User_id);
		Task<IEnumerable<User>> GetByEmail(string Email);

		Task<User> Create(User user);

		Task Update(User user);

		Task Delete(Guid User_id);
        Task<IEnumerable<User>> Get();

    }
}
