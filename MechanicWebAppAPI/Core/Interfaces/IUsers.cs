using MechanicWebAppAPI.Common.Requests.Authentication;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IUsers
    {

        Task<User> Get(Guid User_id);
        Task<User> GetByEmail(string Email);
        Task Update(User user);

        Task Delete(Guid User_id);
        Task<IEnumerable<User>> Get();
       // Task Create(RegisterRequest user);
    }
}
