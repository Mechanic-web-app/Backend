using System.ComponentModel.DataAnnotations;


namespace MechanicWebAppAPI.Common.Requests.Authentication
{
    public class RegisterByAdminRequest : RegisterRequest
    {
        [Required]
        public string Role { get; set; }
    }
}
