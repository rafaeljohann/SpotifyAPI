using Microsoft.AspNetCore.Mvc;

namespace Spotify.Domain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MusicaController : ControllerBase
{

    [HttpGet(Name = "ObterMusicasMaisPopulares")]
    public IActionResult ObterMusicasMaisPopulares()
    {
        return Ok();
    }
}
