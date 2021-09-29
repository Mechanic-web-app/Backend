using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Models;
using MechanicWebAppAPI.Repositories;
using MechanicWebAppAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MechanicWebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoles _roleRepository;

        public RolesController(IRoles RoleRepository)
        {
            _roleRepository = RoleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _roleRepository.Get();
        }
        [HttpGet("{Role_id}")]
        public async Task<ActionResult<Role>> GetRoles(Guid Role_id)
        {
            return await _roleRepository.Get(Role_id);
        }
        [HttpPost]
        public async Task<ActionResult<Role>> PostRoles([FromBody] Role role)
        {
            var newRole = await _roleRepository.Create(role);
            return CreatedAtAction(nameof(GetRoles), new { id = newRole.Role_id }, newRole);
        }

        [HttpPut]
        public async Task<ActionResult> PutRoles(Guid Role_id, [FromBody] Role role)
        {
            if (Role_id != role.Role_id)
            {
                return BadRequest();
            }

            await _roleRepository.Update(role);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid Role_id)
        {
            var roleToDelete = await _roleRepository.Get(Role_id);
            if (roleToDelete == null)
                return NotFound();

            await _roleRepository.Delete(roleToDelete.Role_id);
            return NoContent();
        }
    }
}
