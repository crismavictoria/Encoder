using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncodeController : ControllerBase
    {
        private readonly IEncodingService _encodingService;

        public EncodeController(IEncodingService encodingService)
        {
            _encodingService = encodingService;
        }

        [HttpPost]
        public async Task<IActionResult> Encode([FromBody] string text)
        {
            var cancellationToken = HttpContext.RequestAborted;

            if (!_encodingService.CanEncode())
            {
                return BadRequest("Another encoding process is already in progress.");
            }

            var result = await _encodingService.Encode(text, cancellationToken);

            if (cancellationToken.IsCancellationRequested)
            {
                return Ok("Encoding process cancelled.");
            }

            return Ok(result);
        }

        [HttpPost("cancel")]
        public IActionResult Cancel()
        {
            _encodingService.Cancel();
            return Ok("Encoding process cancelled.");
        }
    }
}
