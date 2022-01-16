using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicWebAppAPI.Data.Models
{

    public class Repair
    {
        [Key]
        public Guid Repair_id { get; set; }

        public string Repair_description { get; set; }

        public decimal Repair_cost { get; set; }

        public string Repair_date { get; set; }


        public Guid Repaired_car_id { get; set; }
        public Car Car { get; set; }

    }
}

