using MechanicWebAppAPI.Api.Responses.Factories;
using MechanicWebAppAPI.Api.Responses.Wrappers;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Common.Requests.Authentication;
using MechanicWebAppAPI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Api.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthentication _authenticationRepository;

        public AuthenticationController(IApiResponseFactory responseFactory, IAuthentication authenticationRepository) : base(responseFactory)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<JwtToken>))]
        public async Task<IActionResult> Register(RegisterRequest request) => CreateSuccessResponse(await _authenticationRepository.Register(request).ConfigureAwait(false));

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<JwtToken>))]
        public async Task<IActionResult> LogIn(LoginRequest request) => CreateSuccessResponse(await _authenticationRepository.Login(request).ConfigureAwait(false));

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<bool>))]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request) => CreateSuccessResponse(await _authenticationRepository.ChangePassword(request).ConfigureAwait(false));
    }
}

