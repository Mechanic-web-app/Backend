
using MechanicWebAppAPI.Common.Helpers;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MechanicWebAppAPI.Core.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        private readonly AppSettings _appSettings;
        private string _token;

        public JwtHelper(IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _token = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        public JwtToken GenerateJwtToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", user.Email ),
                    new Claim("Name", user.Name ),
                    new Claim("Lastname", user.Lastname ),
                    new Claim("Role", user.Role )
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return new JwtToken()
            {
                AccessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
            };
        }

        public Guid GetUserId()
        {
            try
            {
                if (_token.StartsWith("Bearer "))
                {
                    _token = _token["Bearer ".Length..];
                }
                var handler = new JwtSecurityTokenHandler() { SetDefaultTimesOnTokenCreation = false };
                var payload = handler.ReadJwtToken(_token.Trim());
                var result = Guid.TryParse(payload.Payload.Values.First().ToString(), out var userId);
                return result ? userId : Guid.Empty;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}