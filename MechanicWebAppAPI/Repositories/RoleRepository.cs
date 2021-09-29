using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Data;
using MechanicWebAppAPI.Models;
using MechanicWebAppAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MechanicWebAppAPI.Repositories
{
    public class RoleRepository : IRoles
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Role> Create(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task Delete(Guid Role_id)
        {
            var roleToDelete = await _context.Roles.FindAsync(Role_id);
            _context.Roles.Remove(roleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> Get(Guid Role_id)
        {
            return await _context.Roles.FindAsync(Role_id);
        }

        public async Task Update(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
