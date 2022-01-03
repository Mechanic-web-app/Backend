using AutoMapper;
using MechanicWebAppAPI.Common.Requests.RepairRequests;
using MechanicWebAppAPI.Core.Dtos.Repair;
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
    public class RepairRepository : BaseRepository, IRepairs
    {

        public RepairRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<RepairDto> Create(RepairAddRequest repair)
        {
            var repairDto = _mapper.Map<RepairAddRequest, Repair>(repair);
            repairDto.Repair_id = Guid.NewGuid();
            repairDto.Repaired_car_id = repair.Repaired_car_id;
            _context.Repairs.Add(repairDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<Repair, RepairDto>(repairDto);
        }

        public async Task Delete(Guid Repair_id)
        {
            var repairToDelete = await _context.Repairs.FindAsync(Repair_id);
            _context.Repairs.Remove(repairToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RepairDto>> Get()
        {
            return await _context.Repairs.Select(repair => _mapper.Map<Repair, RepairDto>(repair)).ToListAsync();
        }

        public async Task<Repair> Get(Guid Repair_id)
        {
            return await _context.Repairs.FindAsync(Repair_id);
        }
        public async Task<IEnumerable<RepairDto>> GetByCar(Guid Repaired_car_id)
        {
            return await _context.Repairs.Where(x => x.Repaired_car_id == Repaired_car_id).Select(repair => _mapper.Map<Repair, RepairDto>(repair)).ToListAsync();
        }


        public async Task Update(Repair repair)
        {
            _context.Entry(repair).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
