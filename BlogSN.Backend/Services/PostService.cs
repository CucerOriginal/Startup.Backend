using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Models;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Services;

public class PostService : IPostService
{
    private readonly BlogSnDbContext _context;
    private readonly IUserServive _userServive;
    private readonly IEmployerService _employerService;


    public PostService(BlogSnDbContext context, IUserServive userServive, IEmployerService employerService)
    {
        _context = context;
        _userServive = userServive;
        _employerService = employerService;
    }

    public async Task CreatePost(Post post, CancellationToken cancellationToken)
    {
        await _context.Post.AddAsync(post, cancellationToken);
        var user = await _employerService.GetEmployerById(post.EmployerId, cancellationToken);
        user.PostsCount++;

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            if (await _context.IsPostExists(post.Id))
                throw new BadRequestException($"There is already exists task with {{id}} = {post.Id}");
            else
                throw;
        }
    }

    public async Task DeletePostById(int id, CancellationToken cancellationToken)
    {
        var post = await GetPostById(id, cancellationToken);
        if (!(post.EmployerId == null)){
            var user = await _employerService.GetEmployerById(post.EmployerId, cancellationToken);
            user.PostsCount--;
        }
        _context.Post.Remove(post);
        await _context.SaveChangesAsync(cancellationToken);
    }

	public async Task<IEnumerable<Applicant>> GetApplicantsFeedbackedPostByPostId(int postId, CancellationToken cancellationToken)
	{
        var applicantsFeedbackedPost = await _context.Applicant.Include(p=> p.Feedbacks).Where(x => x.Feedbacks.Where(p=> p.PostId == postId) != null).ToListAsync(cancellationToken);

        if (!applicantsFeedbackedPost.Any())
        {
            throw new NotFoundException($"Employer has no comments");
        }

        return applicantsFeedbackedPost;
    }

	public async Task<Post> GetPostById(int id, CancellationToken cancellationToken)
    {

        var post = await _context.Post.Include(p => p.Employer).Include(p=> p.Category).FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (post is null)
        {
            throw new NotFoundException($"No post with id = {id}");

        }
        return post;

    }

    public async Task<IEnumerable<Post>> GetPosts(CancellationToken cancellationToken)
    {
        var post = await _context.Post.Include(p => p.Employer).Include(p=> p.Category).ToListAsync(cancellationToken);

        if (!post.Any())
        {
            throw new NotFoundException($"No task fround");
        }
        return post;
    }

    public async Task UpdatePostById(int id, Post post, CancellationToken cancellationToken)
    {
        if (id != post.Id)
        {
            throw new BadRequestException("id from the route is not equal to id from passed object");
        }
        
        if (!await _context.IsPostExists(id))
            throw new NotFoundException($"There is no post with {{id}} = {id}.");
        
        _context.Entry(post).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }
}