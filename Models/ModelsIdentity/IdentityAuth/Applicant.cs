using Models.ModelsBlogSN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.ModelsIdentity.IdentityAuth
{
	/// <summary>
	/// Соискатель.
	/// </summary>
	public class Applicant
	{
		[Key]
		public string Id { get; set; }

		public IList<Resume>? Resumes { get; set; }

		[JsonIgnore]
		public IList<Feedback>? Feedbacks { get; set; }

		[JsonIgnore]
		public IList<Comment>? Comments { get; set; }

		[JsonIgnore]
		public IList<Rating>? Ratings { get; set; }

		public string? Requisite { get; set; }

		public virtual ApplicationUser? User { get; set; }
	}
}
