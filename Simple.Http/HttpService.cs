using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Simple.Http;

public class HttpService : IHttpService
{
	public HttpClient HttpClient { get; set; }

	public HttpService()
	{
		if (HttpClient == null)
			HttpClient = new HttpClient();
	}


	public async Task<SimpleHttpResult> SendRequestAsync(string url, HttpMethod httpMethod, object body = null, string bearer = "")
	{
		var simpleHttpResult = new SimpleHttpResult();

		try
		{
			// If bearer isnt null, add to request header
			if (!string.IsNullOrEmpty(bearer))
				HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);

			var httpRequestMessage = new HttpRequestMessage() { Method = httpMethod, RequestUri = new Uri(url) };

			if (body != null)
				httpRequestMessage.Content = JsonContent.Create(body);

			var response = await HttpClient.SendAsync(httpRequestMessage);
			simpleHttpResult.RequestMessage = response?.RequestMessage;
			simpleHttpResult.HttpStatusCode = response?.StatusCode ?? System.Net.HttpStatusCode.NotFound;

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
			// If bearer isnt null, add to request header
			if (!string.IsNullOrEmpty(bearer))
				HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);

			var httpRequestMessage = new HttpRequestMessage() { Method = httpMethod, RequestUri = new Uri(url) };

			if (body != null)
				httpRequestMessage.Content = JsonContent.Create(body);

			var response = await HttpClient.SendAsync(httpRequestMessage);
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
