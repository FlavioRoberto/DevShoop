using System.Net.Http.Headers;
using System.Text.Json;

namespace DevShoop.Web.Extensions;

public static class HttpClientExtension
{
    private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

    public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"Ocorreu um erro ao chamar a api: {response.ReasonPhrase}");

        var data = await response.Content
                                 .ReadAsStringAsync()
                                 .ConfigureAwait(false);

        var jsonSerializerOption = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        return JsonSerializer.Deserialize<T>(data, jsonSerializerOption);
    }

    public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var content = CreateContent(data);
        return httpClient.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var content = CreateContent(data);
        return httpClient.PutAsJson(url, content);
    }

    public static Task<HttpResponseMessage> Get(this HttpClient httpClient, string url)
    {
        return httpClient.GetAsync(url);
    }

    public static Task<HttpResponseMessage> Delete(this HttpClient httpClient, string url)
    {
        return httpClient.DeleteAsync(url);
    }

    private static StringContent CreateContent<T>(T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);

        var content = new StringContent(dataAsString);
        content.Headers.ContentType = contentType;

        return content;
    }
}
