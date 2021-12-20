using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Repositories
{
    public class OpinionRepository : IOpinions
    {
        private readonly AppDbContext _context;

        public OpinionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Opinion> Create(Opinion opinion)
        {
            _context.Opinions.Add(opinion);
            await _context.SaveChangesAsync();

            return opinion;
        }

        public async Task Delete(Guid Opinion_id)
        {
            var opinionToDelete = await _context.Opinions.FindAsync(Opinion_id);
            _context.Opinions.Remove(opinionToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Opinion>> Get()
        {
            return await _context.Opinions.ToListAsync();
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
