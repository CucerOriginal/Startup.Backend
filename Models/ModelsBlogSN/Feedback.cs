using BlogSN.Models;
using Models.ModelsIdentity.IdentityAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.ModelsBlogSN
{
	public class Feedback
	{
		[Key]
		public string Id { get; set; }

		public int PostId { get; set; }

		[JsonIgnore]
		public Post? Post { get; set; }

		public string? ApplicationUserId { get; set; }

		/// <summary>
		/// Ответ hr-а.
		/// </summary>
		public bool Answer { get; set; }

		/// <summary>
		/// В работе.
		/// </summary>
		public bool AtWork { get; set; }

		[JsonIgnore]
		public ApplicationUser? ApplicationUser { get; set; }

		public string? ResumeId { get; set; }

		[JsonIgnore]
		public Resume? Resume { get; set; }
	}
}
