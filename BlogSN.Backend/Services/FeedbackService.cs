﻿using BlogSN.Backend.Data;
using BlogSN.Backend.Exceptions;
using BlogSN.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services
{
	public class FeedbackService : IFeedbackService
	{
		private readonly BlogSnDbContext _context;

		public FeedbackService(BlogSnDbContext context)
		{
			_context = context;
		}

		public async Task CreateFeedback(Feedback feedback, CancellationToken cancellationToken)
		{
			var feedbackSearch = await _context.Feedback.FirstOrDefaultAsync(p => p.Id == feedback.Id);

			if (feedbackSearch != null)
			{
				throw new BadRequestException($"Feedback is already exist");
			}

			await _context.Feedback.AddAsync(feedback, cancellationToken);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteFeedbackById(string feedbackId, CancellationToken cancellationToken)
		{
			var feedback = await _context.Feedback.FirstOrDefaultAsync(p => p.Id == feedbackId, cancellationToken);

			if (feedback == null)
			{
				throw new NotFoundException($"No feedback with id = {feedbackId}");
			}

			_context.Remove(feedback);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateFeedbackById(string feedbackId, Feedback feedback, CancellationToken cancellationToken)
		{
			if (feedback == null)
			{
				throw new BadRequestException("resume is null");
			}

			if (feedbackId != feedback.Id)
			{
				throw new BadRequestException("id from the route is not equal to id from passed object");
			}

			feedback.AtWork = false;
			_context.Entry(feedback).State = EntityState.Modified;
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
