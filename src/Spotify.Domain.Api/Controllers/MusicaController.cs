using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spotify.Domain.Commands;

namespace Spotify.Domain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MusicaController : ControllerBase
{
    private readonly IMediator _mediator;

    public MusicaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("ObterMusicas")]
    public async Task<IActionResult> ObterMusicasMaisPopulares(
        [FromBody] ObterMusicasCommand obterMusicasCommand)
    {
        var result = await _mediator.Send(obterMusicasCommand);

        if (result is null)
            return Ok();
        
        Response.Headers.Add("Content-Disposition",
            "attachment;filename=RelatorioMusicasSpotify.csv");
        
        return File(result, "text/csv");
    }
}
