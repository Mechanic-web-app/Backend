using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Models
{
	public class User
	{
		[Key]
		public Guid User_id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public string Name { get; set; }
		public string Lastname { get; set; }
		public string Phone_number { get; set; }
		public string User_confirmed { get; set; }
		public Guid User_role { get; set; }
    }
}
