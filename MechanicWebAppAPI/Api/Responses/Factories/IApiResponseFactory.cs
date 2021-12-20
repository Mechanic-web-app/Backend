using MechanicWebAppAPI.Api.Responses.Wrappers;

namespace MechanicWebAppAPI.Api.Responses.Factories
{
    public interface IApiResponseFactory
    {
        public ApiSuccessResponse<T> Success<T>(T data) => new ApiSuccessResponse<T>(true, data);
    }
}
