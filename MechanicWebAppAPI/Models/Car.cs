using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Models
{

	public class Car
	{
		[Key]
		public Guid Car_id { get; set; }

		public string Car_brand { get; set; }

		public string Car_model { get; set; }

		public string Car_reg_number { get; set; }

		[ForeignKey("User_id)")]
		public int Car_user_id { get; set; }

		public Guid User_id { get; set; }
	}
}
