using MechanicWebAppAPI.Common.Requests.Authentication;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IUsers
    {

        Task<IEnumerable<UserDto>> GetById(Guid User_id);
        Task<User> Get(Guid User_id);
        Task Update(User user);

        Task Delete(Guid User_id);
        Task<IEnumerable<UserDto>> Get();
    }
}
