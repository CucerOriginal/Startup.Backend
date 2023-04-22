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

		public string? ApplicantId { get; set; }

		[JsonIgnore]
		public Applicant? Applicant { get; set; }
	}
}
