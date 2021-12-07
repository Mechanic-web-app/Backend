using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Models
{
	public class Repair
	{
		[Key]
		public Guid Repair_id { get; set; }

		public string Repair_description { get; set; }

		public int Repair_cost { get; set; }

		public string Repair_date { get; set; }

		
		public Guid Repaired_car_id { get; set; }
		[ForeignKey("Car_id")]
		public Car Car { get; set; }

		
		public Guid Repaired_car_user_id { get; set; }
		[ForeignKey("User_id")]
		public User User { get; set; }
	}
}

