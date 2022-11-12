using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Simple.Http;

public class HttpService : IHttpService
{
	public HttpClient HttpClient { get; set; }

	public HttpService()
	{
		HttpClient ??= new HttpClient();
	}

	private async Task<HttpResponseMessage> GetContentAsync(string url, HttpMethod httpMethod, object body = null, string bearer = "")
	{
		if (!string.IsNullOrEmpty(bearer))
			HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
		
		// Set the httpMethod and the url
		var httpRequestMessage = new HttpRequestMessage() { Method = httpMethod, RequestUri = new Uri(url)};

		// If the body is not null we add it in the request content
		if (body != null)
			httpRequestMessage.Content = JsonContent.Create(body);

		return await HttpClient.SendAsync(httpRequestMessage);
	}

	public async Task<SimpleHttpResult> SendRequestAsync(string url, HttpMethod httpMethod, object body = null, string bearer = "")
	{
		var simpleHttpResult = new SimpleHttpResult();

		try
		{
			var reponse = await GetContentAsync(url, httpMethod, body, bearer);

			simpleHttpResult.HttpStatusCode = reponse?.StatusCode ?? System.Net.HttpStatusCode.NotFound;
			simpleHttpResult.RequestMessage = reponse?.RequestMessage;

			return new SimpleHttpResult(reponse);
		}
		catch (Exception ex)
		{
			simpleHttpResult.Exception = ex;
		}
		
		return simpleHttpResult;
	}

	public async Task<SimpleHttpResult<TResult>> SendRequestAsync<TResult>(string url, HttpMethod httpMethod, object body = null, string bearer = "")
	{
		var simpleHttpResult = new SimpleHttpResult<TResult>();

		try
		{
			var response = await GetContentAsync(url, httpMethod, body, bearer);
			simpleHttpResult.RequestMessage = response?.RequestMessage;
			simpleHttpResult.HttpStatusCode = response?.StatusCode ?? System.Net.HttpStatusCode.NotFound;

			if (response?.IsSuccessStatusCode ?? false)
				simpleHttpResult.Result = JsonConvert.DeserializeObject<TResult>(await response?.Content?.ReadAsStringAsync());
		}
		catch (Exception ex)
		{
			simpleHttpResult.Exception = ex;
		}
		return simpleHttpResult;
	}
}