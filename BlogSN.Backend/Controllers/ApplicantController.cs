using BlogSN.Backend.Services;
using BlogSN.Models;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsBlogSN;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class ApplicantController : Controller
	{
        private readonly IApplicantService _service;

        public ApplicantController(IApplicantService service)
        {
            _service = service;
        }

        [HttpGet("{applicantId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Applicant))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Applicant>> GetApplicant(string applicantId, CancellationToken cancellationToken)
        {
            var applicant = await _service.GetApplicantById(applicantId, cancellationToken);

            return applicant;
        }

        [HttpGet("{applicantId}/resumes")]
        public async Task<ActionResult<IEnumerable<Resume>>> GetResumesByApplicantId(string applicantId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetResumesByApplicantId(applicantId, cancellationToken));
        }

        [HttpGet("{applicantId}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByApplicantId(string applicantId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetCommentsByApplicantId(applicantId, cancellationToken));
        }

        [HttpGet("{applicantId}/feedbacks")]
        public async Task<ActionResult<IEnumerable<Post>>> GetFeedbackedPostsByApplicantId(string applicantId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetFeedbackedPostsByApplicantId(applicantId, cancellationToken));
        }

        [HttpGet("{applicantId}/ratings")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRattingByApplicantId(string applicantId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetRatingsByApplicantId(applicantId, cancellationToken));
        }

        [HttpDelete("{applicantId}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteApplicant(string applicantId, CancellationToken cancellationToken)
        {
            await _service.DeleteApplicantById(applicantId, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Employer>>> GetApplicants(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetApplicants(cancellationToken));
        }
    }
}
