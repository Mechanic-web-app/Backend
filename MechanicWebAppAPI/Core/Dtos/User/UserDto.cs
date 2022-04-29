﻿using System;

namespace MechanicWebAppAPI.Core.Dtos.User
{
    public class UserDto
    {
        public Guid User_id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
        public string Phone_number { get; set; }

        public bool User_confirmed { get; set; }

    }
    
}
