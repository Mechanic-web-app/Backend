namespace MechanicWebAppAPI.Api.Responses.Wrappers
{
    /// <summary>
    /// Abstract class for all responses
    /// </summary>
    public abstract class ApiResponse
    {
        /// <summary>
        /// Operation status
        /// </summary>
        public bool Success { get; set; }

        protected ApiResponse(bool success)
        {
            Success = success;
        }
    }
}