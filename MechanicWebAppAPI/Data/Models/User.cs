using System;
using System.ComponentModel.DataAnnotations;

namespace MechanicWebAppAPI.Data.Models

{
    public class User
    {
        [Key]
        public Guid User_id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone_number { get; set; }
        public bool User_confirmed { get; set; }
        public string Role { get; set; }
        public Guid Token { get; set; }
    }
}
