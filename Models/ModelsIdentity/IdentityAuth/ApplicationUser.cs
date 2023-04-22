using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
using Models.ModelsBlogSN;

namespace Models.ModelsIdentity.IdentityAuth
{
    public class ApplicationUser : IdentityUser
    {
		public virtual Applicant? Applicant { get; set; }

		public virtual string? ApplicantId { get; set; }

		public virtual Employer? Employer { get; set; }

		public virtual string? EmployerId { get; set; }

		public string? Role { get; set; }
	}
}
