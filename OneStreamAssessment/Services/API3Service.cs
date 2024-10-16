using System.Net.Http;
using System.Threading.Tasks;

public class API3Service : IAPI3Service
{
    private readonly HttpClient _httpClient;

    public API3Service(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> CallAPI3Async()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5000/api/API3/data");
        return response;
    }
}
