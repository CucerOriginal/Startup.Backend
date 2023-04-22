using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
    public class RatingService : IRatingService
    {
        private readonly BlogSnDbContext _context;
        private readonly IPostService _postService;
        private readonly IUserServive _userServive;
        private readonly IEmployerService _employerService;

        public RatingService(BlogSnDbContext context, IPostService postService, IUserServive userServive, IEmployerService employerService)
        {
            _userServive = userServive;
            _context = context;
            _postService = postService;
            _employerService = employerService;
        }

        public async Task CreateRatingStatus(Rating rating, CancellationToken cancellationToken)
        {
            var ratingSearch = await _context.Rating.FirstOrDefaultAsync(p => p.Id == rating.Id, cancellationToken);

			if (ratingSearch != null)
			{
                throw new BadRequestException($"Like status {ratingSearch.LikeStatus} is already exist");
            }

            rating.Id = Guid.NewGuid().ToString();

            await _context.Rating.AddAsync(rating, cancellationToken);

            var employer = await _employerService.GetEmployerById(rating.EmployerId, cancellationToken);
            if (rating.LikeStatus)
            {
                employer.RatingCount++;
            }
            else employer.RatingCount--;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRatingStatusById(string id, CancellationToken cancellationToken)
        {
            var rating = await _context.Rating.FirstOrDefaultAsync(p=> p.Id == id, cancellationToken);
            if (rating is null)
            {
                throw new NotFoundException($"No rating with id = {id}");
            }

            var employer = await _employerService.GetEmployerById(rating.EmployerId, cancellationToken);
            if (rating.LikeStatus)
            {
                employer.RatingCount--;
            }
            else employer.RatingCount++;
            _context.Remove(rating);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateRatingStatusById(string id, Rating rating, CancellationToken cancellationToken)
        {
            if (id != rating.Id)
            {
                throw new BadRequestException("id from the route is not equal to id from passed object");
            }
            var lickCheck = await _context.Rating.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (lickCheck is null)
            {
                throw new NotFoundException($"No rating with id = {id}");
            }

            var employer = await _employerService.GetEmployerById(rating.EmployerId, cancellationToken);
            if (lickCheck.LikeStatus == rating.LikeStatus)
            {
                _context.Rating.Remove(rating);
                if (rating.LikeStatus)
                {
                    employer.RatingCount--;
                }
                else employer.RatingCount++;
                await _context.SaveChangesAsync(cancellationToken);
                return;
            }

            employer.RatingCount = rating.LikeStatus ? employer.RatingCount + 2 : employer.RatingCount - 2;
            _context.Entry(rating).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
