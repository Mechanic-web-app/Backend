using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Dtos.User
{
    public class UserDto
    {
        public Guid User_id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string User_role { get; set; }
    }
}
