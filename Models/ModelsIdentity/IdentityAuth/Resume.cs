﻿using BlogSN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.ModelsIdentity.IdentityAuth
{
	//Добавить город проживания и дату рождения и график.
	public class Resume
	{
		public Resume()
		{
			DateCreated = DateTime.UtcNow;
		}

		[Key]
		public string Id { get; set; }

		/// <summary>
		/// Желаемая должность.
		/// </summary>
		public string Title { get; set; }

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

		[JsonIgnore]
		public Category? Category { get; set; }

		public int? CategoryId { get; set; }

		public DateTime? DateCreated { get; set; }

		[JsonIgnore]
		public ApplicationUser? ApplicationUser { get; set; }

		public string? ApplicationUserId { get; set; }
	}
}
