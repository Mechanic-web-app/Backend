﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicWebAppAPI.Data;
using MechanicWebAppAPI.Models;
using MechanicWebAppAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MechanicWebAppAPI.Repositories
{
    public class UserRepository : IUsers
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
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

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(Guid User_id)
        {
            return await _context.Users.FindAsync(User_id);
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
