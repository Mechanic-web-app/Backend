using MechanicWebAppAPI.Api.Responses.Wrappers;
using MechanicWebAppAPI.Common.Requests.Authentication;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<bool>))]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{User_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<bool>))]
        public async Task<IEnumerable<UserDto>> Get(Guid User_id)
        {
            return await _userRepository.GetById(User_id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<bool>))]
        public async Task<ActionResult> PutUsers(Guid User_id, [FromBody] User user)
        {
            if (User_id != user.User_id)
            {
                return BadRequest();
            }

            await _userRepository.Update(user);

            return NoContent();
        }
        
        [HttpDelete("{User_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<bool>))]
        public async Task<ActionResult> Delete(Guid User_id)
        {
            var userToDelete = await _userRepository.Get(User_id);
            if (userToDelete == null)
                return NotFound();

            await _userRepository.Delete(userToDelete.User_id);
            return NoContent();
        }
    }
}
