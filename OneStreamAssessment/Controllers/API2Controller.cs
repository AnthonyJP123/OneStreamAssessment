using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class API2Controller : ControllerBase
{
    [HttpGet("data")]
    public async Task<IActionResult> GetDataFromApi2()
    {
        await Task.Delay(2000); // Simulate long-running operation
        return Ok("Data from API2");
    }
}
