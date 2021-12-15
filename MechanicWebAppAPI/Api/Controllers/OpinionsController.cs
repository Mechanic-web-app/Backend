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
    public class OpinionsController : ControllerBase
    {
        private readonly IOpinions _opinionRepository;

        public OpinionsController(IOpinions OpinionRepository)
        {
            _opinionRepository = OpinionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Opinion>> GetOpinions()
        {
            return await _opinionRepository.Get();
        }
        [HttpGet("{Opinion_id}")]
        public async Task<ActionResult<Opinion>> GetOpinions(Guid Opinion_id)
        {
            return await _opinionRepository.Get(Opinion_id);
        }
        [HttpPost]
        public async Task<ActionResult<Opinion>> PostOpinions([FromBody] Opinion opinion)
        {
            var newOpinion = await _opinionRepository.Create(opinion);
            return CreatedAtAction(nameof(GetOpinions), new { id = newOpinion.Opinion_id }, newOpinion);
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

