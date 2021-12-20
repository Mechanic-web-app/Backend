using AutoMapper;
using MechanicWebAppAPI.Common.CustomExceptions;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Common.Requests.Authentication;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using MechanicWebAppAPI.Data.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Repositories
{
    public class AuthenticationRepository : BaseRepository, IAuthentication
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly PasswordHasher<User> _passwordHasher;
        public AuthenticationRepository(AppDbContext context, IMapper mapper, IJwtHelper jwtHelper) : base(context, mapper)
        {
            _jwtHelper = jwtHelper;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Token == request.Token).ConfigureAwait(false);
            if (user != null)
            {
                user.Password = _passwordHasher.HashPassword(user, request.NewPassword);
                user.Token = Guid.Empty;
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            throw new ServiceLayerException(HttpStatusCode.NotFound, "Token expired");
        }

        public async Task<JwtToken> Login(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Email == request.Email && i.User_confirmed).ConfigureAwait(false);
            if (user == null)
                throw new ServiceLayerException(HttpStatusCode.NotFound, "User not found");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result == PasswordVerificationResult.Success)
                return _jwtHelper.GenerateJwtToken(_mapper.Map<User, UserDto>(user));

            throw new ServiceLayerException(HttpStatusCode.Unauthorized, "The email or password is incorrect");
        }

        public async Task<Guid> Register(RegisterRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Email == request.Email).ConfigureAwait(false);
            if (user == null)
            {
                var userResult = await _context.Users.AddAsync(new User()
                {
                    Email = request.Email,
                    Name =  request.Name,
                    Lastname = request.Lastname,
                    Phone_number = request.Phone_number,
                    User_confirmed = false,
                    Token = Guid.Empty,
                    Role = Role.User
                }).ConfigureAwait(false);

                userResult.Entity.Password = _passwordHasher.HashPassword(userResult.Entity, request.Password);

                await _context.SaveChangesAsync().ConfigureAwait(false);
                return userResult.Entity.User_id;
            }
            throw new ServiceLayerException(HttpStatusCode.BadRequest, "Email is already used");
        }
    }
}
