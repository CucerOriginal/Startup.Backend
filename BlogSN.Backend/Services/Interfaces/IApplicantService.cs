using BlogSN.Models;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
	public interface IApplicantService
	{
        public Task<Applicant> GetApplicantById(string id, CancellationToken cancellationToken);

        public Task DeleteApplicantById(string userId, CancellationToken cancellationToken);

        public Task<IEnumerable<Resume>> GetResumesByApplicantId(string id, CancellationToken cancellationToken);

        public Task<IEnumerable<Post>> GetFeedbackedPostsByApplicantId(string userid, CancellationToken cancellationToken);

        public Task<IEnumerable<Comment>> GetCommentsByApplicantId(string userId, CancellationToken cancellationToken);

        public Task<IEnumerable<Rating>> GetRatingsByApplicantId(string userId, CancellationToken cancellationToken);

        public Task<IEnumerable<Applicant>> GetApplicants(CancellationToken cancellationToken);
    }
}
