using System.Net;
using Simple.Http.Tests.Models;

namespace Simple.Http.Tests;

public class UnitTest
{
    [Fact]
    public async Task TestApiCatFactGet()
    {
        // https://catfact.ninja/fact
        IHttpService httpService = new HttpService();
        var url = "https://catfact.ninja/fact";
        var response = await httpService.SendRequestAsync(url, HttpMethod.Get);
        
        Assert.True(response?.HttpStatusCode == HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task TestApiCatFactGetWithBody()
    {
        // https://catfact.ninja/fact
        IHttpService httpService = new HttpService();
        var url = "https://catfact.ninja/fact";
        var response = await httpService.SendRequestAsync<CatFactDto>(url, HttpMethod.Get);
        
        Assert.True(response?.HttpStatusCode == HttpStatusCode.OK);
        Assert.False(string.IsNullOrEmpty(response?.Result?.Fact));
        Assert.True(response?.Result?.Fact?.Length == response?.Result?.Length);
    }
    
    [Fact]
    public async Task TestApiCatFactPost()
    {
        // https://catfact.ninja/fact
        IHttpService httpService = new HttpService();
        var url = "https://catfact.ninja/fact";
        var response = await httpService.SendRequestAsync(url, HttpMethod.Post);

        Assert.True(response?.HttpStatusCode == HttpStatusCode.NotFound);
    }
    
    
}
