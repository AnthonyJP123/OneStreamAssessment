using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class API3Controller : ControllerBase
{
    [HttpGet("data")]
    public async Task<IActionResult> GetDataFromApi3()
    {
        await Task.Delay(3000); // Simulate long-running operation
        return Ok("Data from API3");
    }
}
