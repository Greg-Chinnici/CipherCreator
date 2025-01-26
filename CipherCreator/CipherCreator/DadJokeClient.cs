using System.Net.Http.Json;

namespace CipherCreator;

public class DadJokeClient : ITextAPI
{
    private HttpClient httpClient;
    
    public DadJokeClient() => httpClient = new HttpClient();
    
    public async Task<string> GetTextAsync()
    {
        try
        {
            
            httpClient.DefaultRequestHeaders.Add("User-Agent", "cipher creator");
            httpClient.DefaultRequestHeaders.Add("Accept", "text/plain");

            HttpResponseMessage response = await httpClient.GetAsync("https://icanhazdadjoke.com/");
            
            response.EnsureSuccessStatusCode();
            
            return response.Content.ReadAsStringAsync().Result;
        }
        catch (HttpRequestException ex)
        {
            return $"Error {ex.Message}";
        }

    }
}