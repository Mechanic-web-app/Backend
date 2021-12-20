
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicWebAppAPI.Data.Models
{

    public class Opinion
    {
        [Key]
        public Guid Opinion_id { get; set; }

        public string Opinion_description { get; set; }

        public int Opinion_rate { get; set; }


        public Guid Opinion_user_id { get; set; }
        [ForeignKey("User_id")]
        public User User { get; set; }

    }
}

