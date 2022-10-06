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

    [HttpGet("ObterMusicas")]
    public async Task<IActionResult> ObterMusicasMaisPopulares()
    {
        var result = await _mediator.Send(new ObterMusicasCommand());

        if (result is null)
            return Ok();
        
        Response.Headers.Add("Content-Disposition",
            "attachment;filename=RelatorioMusicasSpotify.csv");
        
        return File(result, "text/csv");
    }
}
