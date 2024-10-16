using System.Net.Http;
using System.Threading.Tasks;

public class API2Service : IAPI2Service
{
    private readonly HttpClient _httpClient;

    public API2Service(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> CallAPI2Async()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5000/api/API2/data");
        return response;
    }
}
