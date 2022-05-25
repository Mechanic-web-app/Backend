using AutoMapper;
using MechanicWebAppAPI.Common.Requests.OpinionRequests;
using MechanicWebAppAPI.Core.Dtos.Opinion;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Repositories
{
    public class OpinionRepository : BaseRepository, IOpinions
    {

        public OpinionRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<OpinionDto> Create(OpinionAddRequest opinion)
        {
            var opinionDto = _mapper.Map<OpinionAddRequest, Opinion>(opinion);
            opinionDto.Opinion_id = Guid.NewGuid();
            _context.Opinions.Add(opinionDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<Opinion, OpinionDto>(opinionDto);
        }

        public async Task<bool> Delete(Guid Opinion_id)
        {
            var opinionToDelete = await _context.Opinions.FindAsync(Opinion_id);
            _context.Opinions.Remove(opinionToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OpinionDto>> Get()
        {
            return await _context.Opinions.Select(opinion => _mapper.Map<Opinion, OpinionDto>(opinion)).ToListAsync();
        }

        public async Task<Opinion> Get(Guid Opinion_id)
        {
            return await _context.Opinions.FindAsync(Opinion_id);
        }

        public async Task Update(Opinion opinion)
        {
            _context.Entry(opinion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
