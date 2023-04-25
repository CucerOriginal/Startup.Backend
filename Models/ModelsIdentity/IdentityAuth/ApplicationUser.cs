using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
using Models.ModelsBlogSN;

namespace Models.ModelsIdentity.IdentityAuth
{
    public class ApplicationUser : IdentityUser
    {
        [JsonIgnore]
        public IList<Post>? Posts { get; set; }
 
        [JsonIgnore]
        public IList<Comment>? Comments { get; set; }

        [JsonIgnore]
        public IList<Feedback>? Feedbacks { get; set; }

        [JsonIgnore]
        public IList<Resume>? Resumes { get; set; }

        public string? Role { get; set; }

        public string? Requisite { get; set; }

        public int PostsCount { get; set; }
    }
}
