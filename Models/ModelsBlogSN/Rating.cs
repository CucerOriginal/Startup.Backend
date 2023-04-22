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
    public class Rating
    {
        [Key]
        public string Id { get; set; }

        public bool LikeStatus { get; set; }

        public string? EmployerId { get; set; }

        [JsonIgnore]
        public Employer? Employer { get; set; }

        public string? ApplicantId { get; set; }

        [JsonIgnore]
        public Applicant? Applicant { get; set; }
    }
}
