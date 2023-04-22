using Models.ModelsIdentity.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlogSN.Models;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsBlogSN
{
    public class Comment
    {
        public Comment()
        {
            CreatedDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        public string? Content { get; set; }

        public string? EmployerId { get; set; }

        [JsonIgnore]
        public Employer? Employer { get; set; }

        public string? ApplicantId { get; set; }

        [JsonIgnore]
        public Applicant? Applicant { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
