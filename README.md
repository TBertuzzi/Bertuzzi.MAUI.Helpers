# Bertuzzi.MAUI.Helpers

Extensions for HttpClient, Objects, Tasks and image manipulation.
 
###### This is the component, works on iOS, Android and UWP.

**NuGet**

|Name|Info|
| ------------------- | :------------------: |
|Bertuzzi.MAUI.Helpers|[![NuGet](https://img.shields.io/badge/nuget-1.0.0-blue.svg)](https://www.nuget.org/packages/Bertuzzi.MAUI.Helpers/)|

 **Platform Support**

Bertuzzi.MAUI.Helpers is a MAUI library.

## Setup / Usage

There are no initial settings. Simply import the package into the shared project only to enable the extensions.

**HttpClient Extensions**

Extensions to make using HttpClient easy.

* GetAsync<T> : Gets the return of a Get Rest and converts to the object or collection of pre-defined objects.
You can use only the path of the rest method, or pass a parameter dictionary. In case the url has parameters.

```csharp
 public static async Task<ServiceResponse<T>> GetAsync<T>(this HttpClient httpClient, string address);
 public static async Task<ServiceResponse<T>> GetAsync<T>(this HttpClient httpClient, string address,
        Dictionary<string, string> values);
```


* PostAsync<T> : Use post service methods rest asynchronously and return objects if necessary. 

```csharp
 public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient,string address, object dto);
 public static async Task<ServiceResponse<T>> PostAsync<T>(this HttpClient httpClient, string address, object dto);
```

* ServiceResponse<T> : Object that facilitates the return of requests Rest. It returns the Http code of the request, already converted object and the contents in case of errors.

```csharp
public class ServiceResponse<T>
{
  public HttpStatusCode StatusCode { get; private set; }

  public T Value { get; set; }

  public string Content { get; set; }

  public Exception Error { get; set; }
}
```

Example of use :

```csharp
public async Task<List<Model.Todo>> GetTodos()
 {
    try
    {

        //GetAsync Return with Object
        var response = await _httpClient.GetAsync<List<Model.Todo>>("todos");
           
        if (response.StatusCode == HttpStatusCode.OK)
        {
              return response.Value;
        }
        else
        {
            throw new Exception(
                   $"HttpStatusCode: {response.StatusCode.ToString()} Message: {response.Content}");
        }
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
 }
```
**Object Extensions**

Copy the equal properties from one object to another. Useful for converting rest objects to those of your app.
A simple cast extension for objetcs.

Example of use :

```csharp

 private async void LoadTodo()
{
    SampleService sampleService = new SampleService();
            
     //Set Timeout on task
     var todosResult = await sampleService.GetTodos().WithTimeout(5000);

    foreach (var todo in todosResult)
    {
     //Cast Extension
       Todos.Add(todo.Cast<MyTodo>());
    }
}

```
**Task Extensions**

Adds a possibility of timeout on your tasks. Based on MVVM Helpers by James Montemagno (https://github.com/jamesmontemagno/mvvm-helpers).

Example of use :

```csharp
 var todosResult = await sampleService.GetTodos().WithTimeout(5000);
```
**Image Helpers**

Methods of manipulation of images obtained through a url

```csharp
public static Stream GetImageStreamFromUrl(string url);
public static byte[] GetImageByteFromUrl(string url);
public static string ConvertToBase64(Stream stream);
public static byte[] ConvertToByteArray(Stream stream);
```

The complete example can be downloaded here: <https://github.com/TBertuzzi/Bertuzzi.MAUI.Helpers/tree/master/MAUIHelpersSample>

based on my package : https://github.com/TBertuzzi/Xamarin.Helpers
