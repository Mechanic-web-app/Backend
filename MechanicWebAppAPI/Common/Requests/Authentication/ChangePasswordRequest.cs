using System;


namespace MechanicWebAppAPI.Common.Requests.Authentication
{
    public class ChangePasswordRequest
    {
        public string NewPassword { get; set; }
        public Guid Token { get; set; }
    }
}