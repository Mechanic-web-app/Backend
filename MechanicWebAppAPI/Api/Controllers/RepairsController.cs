using MechanicWebAppAPI.Common.Requests.RepairRequests;
using MechanicWebAppAPI.Core.Dtos.Repair;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<RepairDto>> GetRepairs()
        {
            return await _repairRepository.Get();
        }
        [HttpGet("{Repair_id}")]
        public async Task<ActionResult<Repair>> GetRepairs(Guid Repair_id)
        {
            return await _repairRepository.Get(Repair_id);
        }
        [HttpGet("byCar/{Repaired_car_id}")]
        public async Task<IEnumerable<RepairDto>> GetByUser(Guid Repaired_car_id)
        {
            return await _repairRepository.GetByCar(Repaired_car_id);
        }
        [HttpPost]
        public async Task<ActionResult<RepairDto>> PostRepairs([FromBody] RepairAddRequest repair)
        {
            return await _repairRepository.Create(repair);
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
