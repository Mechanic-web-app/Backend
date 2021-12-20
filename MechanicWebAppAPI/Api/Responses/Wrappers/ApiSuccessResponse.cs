

namespace MechanicWebAppAPI.Api.Responses.Wrappers
{
    /// <summary>
    /// Wrapper for a successful response
    /// </summary>
    /// <typeparam name="T">Payload</typeparam>
    public class ApiSuccessResponse<T> : ApiResponse
    {
        /// <summary>
        /// Response payload
        /// </summary>
        public T Data { get; set; }

        public ApiSuccessResponse(bool success, T responseData)
            : base(success)
        {
            Data = responseData;
        }
    }
}