using MechanicWebAppAPI.Api.Responses.Wrappers;

namespace MechanicWebAppAPI.Api.Responses.Factories
{
    public class ApiResponseFactory : IApiResponseFactory
    {
        public ApiSuccessResponse<T> Success<T>(T data) => new ApiSuccessResponse<T>(true, data);

        public ApiErrorResponse Error(string errorMessage) => new ApiErrorResponse(errorMessage);
    }
}
