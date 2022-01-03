using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Common.Requests.OpinionRequests
{
    public class OpinionAddRequest
    {
        [Required]
        public Guid Opinion_user_id { get; set; }
        [Required]
        public string Opinion_description { get; set; }
        [Required]
        public int Opinion_rate { get; set; }
        [Required]
        public string Opinion_user_name { get; set; }
        [Required]
        public string Opinion_user_lastname { get; set; }
    }
}
