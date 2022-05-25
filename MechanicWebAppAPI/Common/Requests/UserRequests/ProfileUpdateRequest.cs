using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Common.Requests.UserRequests
{
    public class ProfileUpdateRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone_number { get; set; }
    }
}
