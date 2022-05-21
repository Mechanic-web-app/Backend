using MechanicWebAppAPI.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Helpers
{
    public class CallerEntry
    { 
        [JsonIgnore]
        public string Group { get; set; }
        [JsonIgnore]
        public string User_id { get; set; }
        public User User { get; set; }
        public string CallerName { get; set; }
        public string CallerLastname { get; set; }

    }
}
