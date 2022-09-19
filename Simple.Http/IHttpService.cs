namespace Simple.Http;

public interface IHttpService
{
	HttpClient HttpClient { get; set; }

	/// <summary>
	/// Send Http Request and return a SimpleHttpResult
	/// </summary>
	/// <param name="url">The full url</param>
	/// <param name="httpMethod">The HTTP Method (Get, Post, Put, Delete)</param>
	/// <param name="body">Your JSON (it will be converted to JSON)</param>
	/// <param name="bearer">Your bearer token, it will be added on the header</param>
	/// <returns>One SimpleHttpResult with many informations into </returns>
	Task<SimpleHttpResult> SendRequestAsync(string url, HttpMethod httpMethod, object body = null, string bearer = "");


	/// <summary>
	/// This method allows to send Http requests on a url and get the body
	/// </summary>
	/// <typeparam name="TResult">How the content of the response should be deserialized</typeparam>
	/// <param name="url">The address to send the request to</param>
	/// <param name="httpMethod">The Http method (HttpMethod.Get, HttpMethod.Post...)</param>
	/// <param name="body">The body to send (it will then be serialized)</param>
	/// <param name="bearer">The bearer token</param>
	/// <returns>This method returns an HttpResult, containing information about the request and the result</returns>
	Task<SimpleHttpResult<TResult>> SendHttpRequest<TResult>(string url, HttpMethod httpMethod, object body = null, string bearer = "");
}
