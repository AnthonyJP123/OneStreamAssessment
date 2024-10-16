using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public TokenController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("generate")]
    public IActionResult GenerateToken()
    {
        var token = _tokenService.GenerateToken();
        return Ok(new { token });
    }
}
