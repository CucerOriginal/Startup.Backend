using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services
{
	public class EmployerService : IEmployerService
	{
        private readonly BlogSnDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public EmployerService(BlogSnDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Employer> GetEmployerById(string employerId, CancellationToken cancellationToken)
        {
            var employer = await _context.Employer.Include(p => p.Posts).Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == employerId, cancellationToken);
            if (employer is null)
            {
                throw new NotFoundException($"No Employer with id = {employerId}");
            }

            return employer;
        }

        public async Task<IEnumerable<Post>> GetPostsByEmployerId(string employerId, CancellationToken cancellationToken)
        {
            var employerPosts = await _context.Post.Where(x => x.EmployerId == employerId).Include(p => p.Category).Include(p => p.Employer).ToListAsync(cancellationToken);
            if (!employerPosts.Any())
            {
                throw new NotFoundException($"Employer has no posts");
            }
            return employerPosts;
        }

        public async Task<IEnumerable<Employer>> GetEmployers(CancellationToken cancellationToken)
        {
            var employers = await _context.Employer.ToListAsync(cancellationToken);
            if (!employers.Any())
            {
                throw new NotFoundException($"No Employer");
            }
            return employers;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByEmployerId(string employerId, CancellationToken cancellationToken)
        {
            var employerComments = await _context.Comment.Where(x => x.EmployerId == employerId).ToListAsync(cancellationToken);
            if (!employerComments.Any())
            {
                throw new NotFoundException($"Employer has no comments");
            }
            return employerComments;
        }

        public async Task<IEnumerable<Rating>> GetRatingsByEmployerId(string employerId, CancellationToken cancellationToken)
        {
            var employerRattings = await _context.Rating.Where(x => x.EmployerId == employerId).ToListAsync(cancellationToken);
            if (!employerRattings.Any())
            {
                throw new NotFoundException("Employer has no rating");
            }
            return employerRattings;
        }

        public async Task DeleteEmployerById(string employerId, CancellationToken cancellationToken)
        {
            var employer = await GetEmployerById(employerId, cancellationToken);

            _context.Employer.Remove(employer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateEmployerById(string employerId, string newName, CancellationToken cancellationToken)
        {
            if (!_context.Employer.Any(p => p.Id == employerId))
                throw new NotFoundException($"There is no Employer with {{id}} = {employerId}.");

            var employer = await _context.Employer.FirstOrDefaultAsync(p => p.Id == employerId);
            if (employer.CompanyName == newName)
            {
                throw new BadRequestException("Cannot be changed to the same name");
            }
            var employers = await _context.Employer.AnyAsync(p => p.CompanyName == newName);
            if (employers)
            {
                throw new BadRequestException("Employer with this name exists");
            }

            employer.CompanyName = newName;

            _context.Entry(employer).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
