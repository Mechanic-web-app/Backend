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

		[ForeignKey("Car_id")]
		public int Repaired_car_id { get; set; }

		public Guid Car_id { get; set; }

		[ForeignKey("User_id")]
		public int Repaired_car_user_id { get; set; }

		public Guid User_id { get; set; }
	}
}

