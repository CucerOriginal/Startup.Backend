using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
	public class ResumeService : IResumeService
	{
		private readonly BlogSnDbContext _context;

		public ResumeService(BlogSnDbContext context)
		{
			_context = context;
		}

		public async Task<Resume> GetResumeById(string resumeId, CancellationToken cancellationToken)
		{
			var resume = await _context.Resume.Include(p => p.Gender).FirstOrDefaultAsync(p => p.Id == resumeId, cancellationToken);

			if (resume == null)
			{
				throw new NotFoundException($"No resume with id = {resumeId}");
			}

			return resume;
		}

		public async Task UpdateResumeById(string resumeId, Resume resume, CancellationToken cancellationToken)
		{
			if (resume == null)
			{
				throw new BadRequestException("resume is null");
			}

			if (resumeId != resume.Id)
			{
				throw new BadRequestException("id from the route is not equal to id from passed object");
			}

			await GetResumeById(resumeId, cancellationToken);

			_context.Entry(resume).State = EntityState.Modified;
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteResumeById(string resumeId, CancellationToken cancellationToken)
		{
			var resume = await GetResumeById(resumeId, cancellationToken);

			_context.Resume.Remove(resume);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task<IEnumerable<Resume>> GetResumes(CancellationToken cancellationToken)
		{
			var resumes = await _context.Resume.Include(p => p.Gender).ToListAsync(cancellationToken);

			if (!resumes.Any())
			{
				throw new NotFoundException("Resumes not found");
			}

			return resumes;
		}

		public async Task CreateResume(Resume resume, CancellationToken cancellationToken)
		{
			await _context.Resume.AddAsync(resume, cancellationToken);

			await _context.SaveChangesAsync(cancellationToken);


			//try
			//{
			//}
			//catch (DbUpdateException e)
			//{
			//	 throw new BadRequestException($"There is already exists resume with {{id}} = {resume.Id}");
			//}
		}
	}
}
