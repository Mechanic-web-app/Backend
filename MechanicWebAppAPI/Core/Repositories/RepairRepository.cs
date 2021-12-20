﻿using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Repositories
{
    public class RepairRepository : IRepairs
    {
        private readonly AppDbContext _context;

        public RepairRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Repair> Create(Repair repair)
        {
            _context.Repairs.Add(repair);
            await _context.SaveChangesAsync();

            return repair;
        }

        public async Task Delete(Guid Repair_id)
        {
            var repairToDelete = await _context.Repairs.FindAsync(Repair_id);
            _context.Repairs.Remove(repairToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Repair>> Get()
        {
            return await _context.Repairs.ToListAsync();
        }

        public async Task<Repair> Get(Guid Repair_id)
        {
            return await _context.Repairs.FindAsync(Repair_id);
        }

        public async Task Update(Repair repair)
        {
            _context.Entry(repair).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
