using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Models;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using BlogSN.Backend.Services;

namespace BlogSN.Backend.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogSnDbContext _context;
        private readonly IPostService _postService;
        private readonly IUserServive _userServive;
        private readonly IEmployerService _employerService;

        public CommentService(BlogSnDbContext context, IPostService postService, IUserServive userServive, IEmployerService employerService)
        {
            _context = context;
            _postService = postService;
            _userServive = userServive;
            _employerService = employerService;
        }

        public async Task CreateComment(Comment comment, CancellationToken cancellationToken)
        {
            await _context.Comment.AddAsync(comment, cancellationToken);
            var employer = await _employerService.GetEmployerById(comment.EmployerId, cancellationToken);
            employer.CommentsCount++;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCommentById(int id, Comment comment, CancellationToken cancellationToken)
        {
            if (id != comment.Id)
            {
                throw new BadRequestException("id from the route is not equal to id from passed object");
            }
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCommentById(int id, CancellationToken cancellationToken)
        {
            var comment = await GetCommentById(id, cancellationToken);
            var employer = await _employerService.GetEmployerById(comment.EmployerId, cancellationToken);
            employer.CommentsCount--;
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Comment> GetCommentById(int id, CancellationToken cancellationToken)
        {
            var comment = await _context.Comment.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            if (comment is null)
            {
                throw new NotFoundException($"No comment with id = {id}");
            }
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetComments(CancellationToken cancellationToken)
        {
            var comments = await _context.Comment.ToListAsync(cancellationToken);
            
            if (!comments.Any())
            {
                throw new NotFoundException($"No comments found");
            }
            return comments;
        }
    }
}
