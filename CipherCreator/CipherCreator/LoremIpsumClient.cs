namespace CipherCreator;

using System.Net.Http;
using System.Threading.Tasks;

public class LoremIpsumClient : ITextAPI
{
    private readonly HttpClient httpClient;
    public LoremIpsumClient() => httpClient = new HttpClient();
    
    public async Task<string> GetTextAsync()
    {
        try
        {
            var response = await httpClient.GetStringAsync("https://loripsum.net/api/1/verylong/prude/plaintext");
            return response;
        }
        catch (HttpRequestException ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}