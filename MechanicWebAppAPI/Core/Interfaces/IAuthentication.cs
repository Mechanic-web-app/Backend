using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Common.Requests.Authentication;
using System;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IAuthentication
    {
        Task<JwtToken> Login(LoginRequest request);
        Task<Guid> Register(RegisterRequest request);
        Task<Guid> RegisterByAdmin(RegisterByAdminRequest request);
        Task<bool> ChangePassword(ChangePasswordRequest request);
    }
}
