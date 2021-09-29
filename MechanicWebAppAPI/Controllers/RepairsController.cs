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
    public class RepairsController : ControllerBase
    {
        private readonly IRepairs _repairRepository;

        public RepairsController(IRepairs RepairRepository)
        {
            _repairRepository = RepairRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Repair>> GetRepairs()
        {
            return await _repairRepository.Get();
        }
        [HttpGet("{Repair_id}")]
        public async Task<ActionResult<Repair>> GetRepairs(Guid Repair_id)
        {
            return await _repairRepository.Get(Repair_id);
        }
        [HttpPost]
        public async Task<ActionResult<Repair>> PostRepairs([FromBody] Repair repair)
        {
            var newRepair = await _repairRepository.Create(repair);
            return CreatedAtAction(nameof(GetRepairs), new { id = newRepair.Repair_id }, newRepair);
        }

        [HttpPut]
        public async Task<ActionResult> PutRepairs(Guid Repair_id, [FromBody] Repair repair)
        {
            if (Repair_id != repair.Repair_id)
            {
                return BadRequest();
            }

            await _repairRepository.Update(repair);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid Repair_id)
        {
            var repairToDelete = await _repairRepository.Get(Repair_id);
            if (repairToDelete == null)
                return NotFound();

            await _repairRepository.Delete(repairToDelete.Repair_id);
            return NoContent();
        }
    }
}
