using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Data.Models;
using MechanicWebAppAPI.Core.Repositories;
using MechanicWebAppAPI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.Get();
        }
        [HttpGet("{User_id}")]
        public async Task<User> Get(Guid User_id)
        {
            return await _userRepository.Get(User_id);
        }
        [HttpGet("GetByEmail/{Email}")]
        public async Task<User> GetByEmail([FromRoute]string Email)
        {
            return await _userRepository.GetByEmail(Email);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUsers([FromBody] User user)
        {
            var newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.User_id }, newUser);
        }

        [HttpPut]
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
