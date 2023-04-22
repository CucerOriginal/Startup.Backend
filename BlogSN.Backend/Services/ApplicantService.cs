using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Models;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
	public class ApplicantService : IApplicantService
	{
		private readonly BlogSnDbContext _context;

		public ApplicantService(BlogSnDbContext context)
		{
			_context = context;
		}


		public async Task<Applicant> GetApplicantById(string applicantId, CancellationToken cancellationToken)
		{
			var applicant = await _context.Applicant
				.Include(p => p.Resumes)
				.Include(p => p.Comments)
				.Include(p => p.Feedbacks)
				.FirstOrDefaultAsync(p => p.Id == applicantId, cancellationToken);
			if (applicant is null)
			{
				throw new NotFoundException($"No Employer with id = {applicantId}");
			}

			return applicant;
		}

		public async Task DeleteApplicantById(string applicantId, CancellationToken cancellationToken)
		{
			var applicant = await GetApplicantById(applicantId, cancellationToken);

			_context.Applicant.Remove(applicant);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task<IEnumerable<Applicant>> GetApplicants(CancellationToken cancellationToken)
		{
			var applicants = await _context.Applicant.ToListAsync(cancellationToken);
			if (!applicants.Any())
			{
				throw new NotFoundException($"No Applicants");
			}
			return applicants;
		}

		public async Task<IEnumerable<Comment>> GetCommentsByApplicantId(string applicantId, CancellationToken cancellationToken)
		{
			var applicantComments = await _context.Comment.Where(x => x.ApplicantId == applicantId).ToListAsync(cancellationToken);

			if (!applicantComments.Any())
			{
				throw new NotFoundException($"Employer has no comments");
			}

			return applicantComments;
		}

		public async Task<IEnumerable<Post>> GetFeedbackedPostsByApplicantId(string applicantId, CancellationToken cancellationToken)
		{
			var feedbackedPosts = await _context.Post.Include(p => p.Feedbacks).Where(x => x.Feedbacks.Where(p => p.ApplicantId == applicantId) != null).ToListAsync(cancellationToken);

			if (!feedbackedPosts.Any())
			{
				throw new NotFoundException($"Employer has no comments");
			}

			return feedbackedPosts;
		}

		public async Task<IEnumerable<Rating>> GetRatingsByApplicantId(string applicantId, CancellationToken cancellationToken)
		{
			var applicantRatings = await _context.Rating.Where(x => x.ApplicantId == applicantId).ToListAsync(cancellationToken);

			if (!applicantRatings.Any())
			{
				throw new NotFoundException($"Employer has no comments");
			}

			return applicantRatings;
		}

		public async Task<IEnumerable<Resume>> GetResumesByApplicantId(string applicantId, CancellationToken cancellationToken)
		{
			var applicantResumes = await _context.Resume.Where(x => x.ApplicantId == applicantId).ToListAsync(cancellationToken);

			if (!applicantResumes.Any())
			{
				throw new NotFoundException($"Employer has no comments");
			}

			return applicantResumes;
		}
	}
}
