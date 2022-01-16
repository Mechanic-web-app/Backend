using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Common.Requests.RepairRequests
{
    public class RepairAddRequest
    {
        [Required]
        public string Repair_description { get; set; }
        [Required]
        public decimal Repair_cost { get; set; }
        [Required]
        public string Repair_date { get; set; }
        [Required]
        public Guid Repaired_car_id { get; set; }
    }
}
