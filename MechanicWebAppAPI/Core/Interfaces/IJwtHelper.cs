

using MechanicWebAppAPI.Data.Models;
using System;
using MechanicWebAppAPI.Common.Jwt;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IJwtHelper
    {
        public JwtToken GenerateJwtToken(User user);
        public Guid GetUserId();
    }
}