using MechanicWebAppAPI.Common.Requests.Authentication;
using MechanicWebAppAPI.Common.Requests.UserRequests;
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
        Task<IEnumerable<UserDto>> GetByNotConfirmed(bool User_confirmed);
        Task<User> Get(Guid User_id);
        Task<bool> Update(Guid User_id, ConfirmUserRequest request);

        Task<bool> Delete(Guid User_id);
        Task<IEnumerable<UserDto>> Get();
    }
}
