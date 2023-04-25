using BlogSN.Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class ResumeController : Controller
	{
        private readonly IResumeService _service;

        public ResumeController(IResumeService service)
        {
            _service = service;
        }

        [HttpPost]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Resume))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Resume>> PostResume(Resume resume, CancellationToken cancellationToken)
        {
            resume.Id = Guid.NewGuid().ToString();
            await _service.CreateResume(resume, cancellationToken);

            return Ok();
        }

        [HttpGet("{resumeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Resume))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Resume>> GetResume(string resumeId, CancellationToken cancellationToken)
        {
            var resume = await _service.GetResumeById(resumeId, cancellationToken);

            return resume;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{resumeId}")]
        //[Authorize]
        public async Task<IActionResult> PutResume(string resumeId, [FromBody] Resume resume, CancellationToken cancellationToken)
        {
            await _service.UpdateResumeById(resumeId, resume, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{resumeId}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteResume(string resumeId, CancellationToken cancellationToken)
        {
            await _service.DeleteResumeById(resumeId, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Resume>>> GetResumes(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetResumes(cancellationToken));
        }
    }
}
