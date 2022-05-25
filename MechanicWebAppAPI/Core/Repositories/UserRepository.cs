using AutoMapper;
using MechanicWebAppAPI.Common.CustomExceptions;
using MechanicWebAppAPI.Common.Requests.UserRequests;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<bool> Delete(Guid User_id)
        {
            var userToDelete = await _context.Users.FindAsync(User_id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return true;
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

        public async Task<IEnumerable<UserDto>> GetByNotConfirmed(bool User_confirmed)
        {
            return await _context.Users.Where(x => x.User_confirmed == false).Select(user => _mapper.Map<User, UserDto>(user)).ToListAsync();
        }
        public async Task<bool> Update(Guid User_id, ConfirmUserRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.User_id == User_id);
            if (user == null)
                throw new ServiceLayerException(HttpStatusCode.NotFound, "User not found");

            user.User_confirmed = request.User_confirmed;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        public async Task<bool> ProfileUpdate(Guid User_id,ProfileUpdateRequest updateRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.User_id == User_id);
            if (user == null)
                throw new ServiceLayerException(HttpStatusCode.NotFound, "User not found");

            user.Email = updateRequest.Email;
            user.Name = updateRequest.Name;
                user.Lastname = updateRequest.Lastname;
                user.Phone_number = updateRequest.Phone_number;
                user.Email = updateRequest.Email;
        await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }


    }
}
