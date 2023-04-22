﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.ModelsIdentity.IdentityAuth
{
	public class Resume
	{
		[Key]
		public string Id { get; set; }

		public string Surname { get; set; }

		public string Name { get; set; }

		public string? Middlename { get; set; }

		[JsonIgnore]
		public Gender? Gender { get; set; }

		public string? GenderId { get; set; }

		public double Salary { get; set; }

		public string? PhoneNumber { get; set; }

		public string? Email { get; set; }

		public string? WorkExperience { get; set; }

		public string? Education { get; set; }

		public string? Description { get; set; }

		public Applicant? Applicant { get; set; }

		public string? ApplicantId { get; set; }
	}
}