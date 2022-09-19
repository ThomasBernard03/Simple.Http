using System.Net;

namespace Simple.Http;
public class SimpleHttpResult
{
	public Exception Exception { get; set; }
	public HttpStatusCode HttpStatusCode { get; set; }
	public HttpRequestMessage RequestMessage { get; set; }

	public SimpleHttpResult()
	{
	}

	public SimpleHttpResult(HttpResponseMessage httpResponseMessage)
	{
		RequestMessage = httpResponseMessage?.RequestMessage;
		HttpStatusCode = httpResponseMessage?.StatusCode ?? HttpStatusCode.NotFound;
	}
}

public class SimpleHttpResult<TResult> : SimpleHttpResult
{
	public TResult Result { get; set; }

	public SimpleHttpResult()
	{
	}

	public SimpleHttpResult(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage)
	{
	}
}
