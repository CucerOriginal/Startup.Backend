using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
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
	public class Employer
	{
		[Key]
		public string Id { get; set; }

		public string? CompanyName { get; set; }

		public string? Description { get; set; }

		[JsonIgnore]
		public IList<Post>? Posts { get; set; }

		[JsonIgnore]
		public IList<Comment>? Comments { get; set; }

		[JsonIgnore]
		public IList<Rating>? Rating { get; set; }

		public int CommentsCount { get; set; }

		public int PostsCount { get; set; }

		public int RatingCount { get; set; }

		public virtual ApplicationUser? User { get; set; }
	}
}
