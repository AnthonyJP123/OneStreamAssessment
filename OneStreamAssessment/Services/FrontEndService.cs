using System.Threading.Tasks;

public class FrontEndService : IFrontEndService
{
    private readonly IAPI2Service _api2Service;
    private readonly IAPI3Service _api3Service;

    public FrontEndService(IAPI2Service api2Service, IAPI3Service api3Service)
    {
        _api2Service = api2Service;
        _api3Service = api3Service;
    }

    public async Task<string> InvokeApi2AndApi3()
    {
        var api2Result = await _api2Service.CallAPI2Async();
        var api3Result = await _api3Service.CallAPI3Async();

        return $"Results: {api2Result}, {api3Result}";
    }
}
