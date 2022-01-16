using System.ComponentModel.DataAnnotations;


namespace MechanicWebAppAPI.Common.Requests.Authentication
{
    public class RegisterRequest : LoginRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Phone_number { get; set; }

    }
}
