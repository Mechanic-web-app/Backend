using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Data.Models;


namespace MechanicWebAppAPI.Core.Interfaces
{
	public interface IUsers
	{

		Task<User> Get(Guid User_id);
		Task<User> GetByEmail(string Email);

		Task<User> Create(User user);

		Task Update(User user);

		Task Delete(Guid User_id);
        Task<IEnumerable<User>> Get();
    }
}
