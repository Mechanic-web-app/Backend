using MechanicWebAppAPI.Api.Responses.Wrappers;
using MechanicWebAppAPI.Common.Requests.Authentication;
using MechanicWebAppAPI.Common.Requests.UserRequests;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Models;
using MechanicWebAppAPI.Data.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _userRepository;

        public UsersController(IUsers UserRepository)
        {
            _userRepository = UserRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{User_id}")]
        public async Task<IEnumerable<UserDto>> Get(Guid User_id)
        {
            return await _userRepository.GetById(User_id);
        }
        [HttpGet("byNotConfirmed/{User_confirmed}")]
        public async Task<IEnumerable<UserDto>> GetByNotConfirmed(bool User_confirmed)
        {
            return await _userRepository.GetByNotConfirmed(User_confirmed);
        }

        [HttpPut("{User_id}")]
        public async Task<bool> Update([FromRoute] Guid User_id, ConfirmUserRequest request)
        {
            return await _userRepository.Update(User_id, request);

        }
        
        [HttpDelete("{User_id}")]
        public async Task<bool> Delete(Guid User_id)
        {
            var userToDelete = await _userRepository.Get(User_id);
            if (userToDelete == null)
                return false;

            await _userRepository.Delete(userToDelete.User_id);
            return true;
        }
    }
}
