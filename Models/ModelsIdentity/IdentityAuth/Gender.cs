using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsIdentity.IdentityAuth
{
	public class Gender
	{
		[Key]
		public string Id { get; set; }

		public string GenderName { get; set; }
	}
}
