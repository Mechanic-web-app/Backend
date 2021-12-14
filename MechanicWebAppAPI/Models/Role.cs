using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Models
{
	public class Role
	{
		[Key]
		public Guid Role_id { get; set; }
		public string Role_description { get; set; }

	}

}
