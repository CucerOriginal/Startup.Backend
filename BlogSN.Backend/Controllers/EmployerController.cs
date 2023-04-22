using BlogSN.Backend.Services;
using BlogSN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class EmployerController : Controller
	{
        private readonly IEmployerService _service;

        public EmployerController(IEmployerService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employer>> GetUser(string employerId, CancellationToken cancellationToken)
        {
            var employer = await _service.GetEmployerById(employerId, cancellationToken);

            return employer;
        }

        [HttpGet("{userId}/posts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(string employerId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetPostsByEmployerId(employerId, cancellationToken));
        }

        [HttpGet("{userId}/comments")]
        public async Task<ActionResult<IEnumerable<Post>>> GetComments(string employerId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetCommentsByEmployerId(employerId, cancellationToken));
        }

        [HttpGet("{userId}/ratings")]
        public async Task<ActionResult<IEnumerable<Post>>> GetRattings(string employerId, CancellationToken cancellationToken)
        {
            return Ok(await _service.GetRatingsByEmployerId(employerId, cancellationToken));
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployer(string employerId, CancellationToken cancellationToken)
        {
            await _service.DeleteEmployerById(employerId, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Employer>>> GetEmployers(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetEmployers(cancellationToken));
        }

        [HttpPut("{userId}/changeName")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCompanyName(string employerId, string newName, CancellationToken cancellationToken)
        {
            await _service.UpdateEmployerById(employerId, newName, cancellationToken);

            return NoContent();
        }
    }
}
