
using MechanicWebAppAPI.Common.Helpers;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Data.Models;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Core.Interfaces;
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
        private string _token;

        public JwtHelper(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = AppSettings.Value;
            _token = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        public JwtToken GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
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