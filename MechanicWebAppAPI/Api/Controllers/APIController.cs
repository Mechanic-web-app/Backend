using MechanicWebAppAPI.Api.Responses.Factories;
using MechanicWebAppAPI.Api.Responses.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MechanicWebAppAPI.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorResponse))]
    public class ApiController : ControllerBase
    {
        private readonly IApiResponseFactory _responseFactory;

        public ApiController(IApiResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
        }

        /// <summary>
        /// Encapsulates the creation of an ApiSuccessResponse
        /// </summary>
        /// <typeparam name="T">type of the response payload</typeparam>
        /// <param name="data">Response payload</param>
        /// <returns><see cref="ObjectResult"/> whith <see cref="HttpStatusCode.OK"/> and <see cref="ApiSuccessResponse{T}"/> as the response</returns>
        protected ObjectResult CreateSuccessResponse<T>(T data) => StatusCode((int)HttpStatusCode.OK, _responseFactory.Success(data));
    }

}
