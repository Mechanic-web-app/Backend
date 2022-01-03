using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Common.Requests.CarRequests
{
    public class CarAddRequest
    {
        [Required]
        public string Car_brand { get; set; }
        [Required]
        public string Car_model { get; set; }
        [Required]
        public string Car_reg_number { get; set; }
        [Required]
        public string Car_user_id { get; set; }
    }
}
