# Simple.Http

![twitter_header_photo_2](https://user-images.githubusercontent.com/67638928/191241272-550df522-215c-4af6-b41d-daa84de90763.png)

[![forthebadge](https://img.shields.io/nuget/v/Simple.Http)](https://www.nuget.org/packages/Simple.Http/)
[![forthebadge](https://img.shields.io/nuget/dt/Simple.Http)](https://www.nuget.org/packages/Simple.Http/)

## Installation 💿

You can install the latest version of the package with the command ```dotnet add package Simple.Http```.
You can also install it manualy in your IDE with the nuget package manager by searching Simple.Http.

## Getting started 🚀

If you're using dependency injection you can register the service thanks to the IHttpService interface. Or, you can use the service manualy by creating a new instance of HttpService.

After this you can use the library.

```C#
var simpleHttpResult = await simpleHttpService.SendRequestAsync(url, HttpMethod.Post, body); 
```
Here we sent an HttpRequest on the route : url with a Post method and a body. In simpleHttpResult we obtain a formatted result : 
```C#
public class SimpleHttpResult
{
	public Exception Exception { get; set; }
	public HttpStatusCode HttpStatusCode { get; set; }
	public HttpRequestMessage RequestMessage { get; set; }
}
```
If an Exception is thrown we can get it into Exception. HttpStatusCode refer to the HttpStatusCode's request. The request message is the message sent to our url.

```C#
// Send a get method and get the request's content
var simpleHttpResult = await simpleHttpService.SendRequestAsync<MyDTO>(url, HttpMethod.Get); 
````

MyDTO class can be like this : 

```C#
public class MyDTO
{
	[JsonProperty("name")]
	public string Name { get; set; }
}
```

If we want to get returned our request's content we must use the method SendRequestAsync<TResult>. We can get the returned value in the Result property.
  
```C#
public class SimpleHttpResult
{
	public Exception Exception { get; set; }
	public HttpStatusCode HttpStatusCode { get; set; }
	public HttpRequestMessage RequestMessage { get; set; }
  	public TResult Result { get; set; }
}
```

## That's all ! ⭐

If you want to help the project, you can put a star on Github. If you have any problems, please let me know by creating an issue on Github or by asking for a pull request.
  
