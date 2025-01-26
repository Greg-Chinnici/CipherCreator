namespace CipherCreator;

public class RonSwansonClient : ITextAPI
{
    private HttpClient httpClient;
    public RonSwansonClient() => httpClient = new HttpClient();
    
    
    public async Task<string> GetTextAsync()
    {
        try
        {
            var response = await httpClient.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes");
            return $"Ron Swanson: {response.Trim('[', ']').Trim('\"')}";
        }
        catch (HttpRequestException ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}