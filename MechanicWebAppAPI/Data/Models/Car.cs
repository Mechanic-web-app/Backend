using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MechanicWebAppAPI.Data.Models
{

    public class Car
    {
        [Key]
        public Guid Car_id { get; set; }

        public string Car_brand { get; set; }

        public string Car_model { get; set; }

        public string Car_reg_number { get; set; }
        public Guid Car_user_id { get; set; }
        public User User { get; set; }

        public ICollection<Repair> Repairs { get; set; }
    }
}
