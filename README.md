# SimpleHttpService

![twitter_header_photo_2](https://user-images.githubusercontent.com/67638928/191241272-550df522-215c-4af6-b41d-daa84de90763.png)

[![forthebadge](https://img.shields.io/nuget/v/Simple.Http)](https://www.nuget.org/packages/Simple.Http/)
[![forthebadge](https://img.shields.io/nuget/dt/Simple.Http)](https://www.nuget.org/packages/Simple.Http/)

## Installation 💿

You can install the last version of the package with the command ```dotnet add package Simple.Http```. You can install it manualy in your IDE nuget package manager by searching Simple.Http.

## Getting started 🚀

If you use dependency injection you can register the service thanks his interface IHttpService. Or, you can use the service manualy by creating a new instance of HttpService.

After this you can use the library.

```C#
var simpleHttpResult = await simpleHttpService.SendHttpRequest(url, HttpMethod.Post, body); 
```
Here we sent an HttpRequest on the route : url with the method Post and a body. In simpleHttpResult we obtain a result formatted : 
```C#
public class SimpleHttpResult
{
	public Exception Exception { get; set; }
	public HttpStatusCode HttpStatusCode { get; set; }
	public HttpRequestMessage RequestMessage { get; set; }
}
```
If an Exception was throwed we can get it into Exception. HttpStatusCode refer to the request HttpStatusCode. The request message is the message sent to our url.

```C#
// Send get method and get the content of the request
var simpleHttpResult = await simpleHttpService.SendHttpRequest<MyDTO>(url, HttpMethod.Get); 
````


MyDTO class can be like this : 

```C#
public class MyDTO
{
	[JsonProperty("name")]
	public string Name { get; set; }
}
```

If we wan't to get returned content of our request we must use the method SendHttpRequest<TResult>. We can get the returned value in the property Result.
  
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

If you want to help the project, put a star on Github. If you have any problems, please let me know by creating an issue on Github or by asking for a pull request.
  

