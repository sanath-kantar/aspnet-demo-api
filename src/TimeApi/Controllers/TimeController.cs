using Microsoft.AspNetCore.Mvc;

namespace TimeApi.Controllers;

[ApiController]
[Route("")]
public class TimeController : ControllerBase
{
    [HttpGet("time")]
    public IActionResult GetTime()
    {
        return Ok(new { utc = DateTime.UtcNow });
    }
}
