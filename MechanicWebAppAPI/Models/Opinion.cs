
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Models
{
	public class Opinion
	{
		[Key]
		public Guid Opinion_id { get; set; }

		public string Opinion_description { get; set; }

		public int Opinion_rate { get; set; }

		[ForeignKey("User_id")]
		public int Opinion_user_id { get; set; }

		public Guid User_id { get; set; }

	}
}

