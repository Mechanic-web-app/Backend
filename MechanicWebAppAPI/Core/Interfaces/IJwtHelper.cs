

using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Data.Models;
using System;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IJwtHelper
    {
        public JwtToken GenerateJwtToken(UserDto user);
        public Guid GetUserId();
    }
}