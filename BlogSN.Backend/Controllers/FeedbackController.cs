using BlogSN.Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsBlogSN;

namespace BlogSN.Backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FeedbackController : Controller
	{
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        //Создать отклик
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback, CancellationToken cancellationToken)
        {
            feedback.Id = feedback.PostId + feedback.ApplicationUserId;
            feedback.FeedbackAtWork = true;
            await _service.CreateFeedback(feedback, cancellationToken);
            return Ok();
        }

        //Удалить отлик
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteFeedback(string id, CancellationToken cancellationToken)
        {
            await _service.DeleteFeedbackById(id, cancellationToken);
            return NoContent();
        }
    }
}
