using MechanicWebAppAPI.Common.Requests.OpinionRequests;
using MechanicWebAppAPI.Core.Dtos.Opinion;
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
    public class OpinionsController : ControllerBase
    {
        private readonly IOpinions _opinionRepository;

        public OpinionsController(IOpinions OpinionRepository)
        {
            _opinionRepository = OpinionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OpinionDto>> GetOpinions()
        {
            return await _opinionRepository.Get();
        }
        [HttpGet("{Opinion_id}")]
        public async Task<ActionResult<Opinion>> GetOpinions(Guid Opinion_id)
        {
            return await _opinionRepository.Get(Opinion_id);
        }
        [HttpPost]
        public async Task<ActionResult<OpinionDto>> PostOpinions([FromBody] OpinionAddRequest opinion)
        {
            return await _opinionRepository.Create(opinion);
        }

        [HttpPut]
        public async Task<ActionResult> PutOpinions(Guid Opinion_id, [FromBody] Opinion opinion)
        {
            if (Opinion_id != opinion.Opinion_id)
            {
                return BadRequest();
            }

            await _opinionRepository.Update(opinion);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid Opinion_id)
        {
            var opinionToDelete = await _opinionRepository.Get(Opinion_id);
            if (opinionToDelete == null)
                return NotFound();

            await _opinionRepository.Delete(opinionToDelete.Opinion_id);
            return NoContent();
        }
    }
}

