using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services.Interfaces
{
	public interface IResumeService
	{
		public Task CreateResume(Resume resume, CancellationToken cancellationToken);

		public Task<Resume> GetResumeById(string resumeId, CancellationToken cancellationToken);

		public Task UpdateResumeById(string resumeId, Resume resume, CancellationToken cancellationToken);

		public Task DeleteResumeById(string resumeId, CancellationToken cancellationToken);

		public Task<IEnumerable<Resume>> GetResumes(CancellationToken cancellationToken);
	}
}
