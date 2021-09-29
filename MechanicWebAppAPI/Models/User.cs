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

		public string Login { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public string Lastname { get; set; }

		public string Phone_number { get; set; }

		[ForeignKey("Role_id")]
		public int User_role { get; set; }

		public Guid Role_id { get; set; }

	}
}
