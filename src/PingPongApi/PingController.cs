using Microsoft.AspNetCore.Mvc;

namespace PingPongApi;

[ApiController]
[Route("")]
public class PingController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Get()
    {
        return Ok(new { status = "ok" });
    }
}
