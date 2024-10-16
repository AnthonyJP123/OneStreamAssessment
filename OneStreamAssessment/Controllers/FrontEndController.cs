using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStreamAssessment.Models;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FrontEndController : ControllerBase
{
    private readonly IFrontEndService _frontEndService;

    public FrontEndController(IFrontEndService frontEndService)
    {
        _frontEndService = frontEndService;
    }

    [HttpGet("invoke")]
    public async Task<IActionResult> InvokeBackendApis()
    {
        var result = await _frontEndService.InvokeApi2AndApi3();
        return Ok(result);
    }

    [HttpPost("invoke")]
    public async Task<IActionResult> PostInvokeBackendApis([FromBody] RequestModel request)
    {
        if (request == null)
        {
            return BadRequest("Request payload cannot be null.");
        }

        var result = await _frontEndService.InvokeApi2AndApi3();
        return Ok(new { message = request.Message, result });
    }
}
