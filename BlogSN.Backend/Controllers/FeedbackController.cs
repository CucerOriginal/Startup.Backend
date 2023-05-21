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
            feedback.AtWork = true;
            await _service.CreateFeedback(feedback, cancellationToken);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> PutFeedback(string id, [FromBody] Feedback feedback, CancellationToken cancellationToken)
        {
            await _service.UpdateFeedbackById(id, feedback, cancellationToken);

            return NoContent();
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
