using AutoMapper;
using MechanicWebAppAPI.Core.Dtos.User;
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
    public class UserRepository : BaseRepository, IUsers
    {

        public UserRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(Guid User_id)
        {
            var userToDelete = await _context.Users.FindAsync(User_id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _context.Users.Select(user => _mapper.Map<User, UserDto>(user)).ToListAsync();
        }

        public async Task<User> Get(Guid User_id)
        {
           return await _context.Users.FindAsync(User_id);
        }

        public async Task<IEnumerable<UserDto>> GetById(Guid User_id)
        {
            return await _context.Users.Where(x => x.User_id == User_id).Select(user => _mapper.Map<User, UserDto>(user)).ToListAsync();
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }


    }
}
