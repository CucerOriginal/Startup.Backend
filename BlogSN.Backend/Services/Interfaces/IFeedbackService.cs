using Models.ModelsBlogSN;

namespace BlogSN.Backend.Services.Interfaces
{
	public interface IFeedbackService
	{
		public Task CreateFeedback(Feedback feedback, CancellationToken cancellationToken);
		public Task DeleteFeedbackById(string feedbackId, CancellationToken cancellationToken);
	}
}
