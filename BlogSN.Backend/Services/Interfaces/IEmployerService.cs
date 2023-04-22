using BlogSN.Models;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
	public interface IEmployerService
	{
        public Task<Employer> GetEmployerById(string employerId, CancellationToken cancellationToken);

        public Task<IEnumerable<Post>> GetPostsByEmployerId(string employerId, CancellationToken cancellationToken);

        public Task<IEnumerable<Employer>> GetEmployers(CancellationToken cancellationToken);

        public Task<IEnumerable<Comment>> GetCommentsByEmployerId(string employerId, CancellationToken cancellationToken);

        public Task DeleteEmployerById(string employerId, CancellationToken cancellationToken);

        public Task UpdateEmployerById(string employerId, string newName, CancellationToken cancellationToken);

        public Task<IEnumerable<Rating>> GetRatingsByEmployerId(string employerId, CancellationToken cancellationToken);
    }
}
