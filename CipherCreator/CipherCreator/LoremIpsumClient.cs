namespace CipherCreator;

using System.Net.Http;
using System.Threading.Tasks;

public class LoremIpsumClient : ITextAPI
{
    private readonly HttpClient httpClient;
    
    private readonly string modifer; // short, medium, long, verylong
    private readonly string[] possibleModifers = {"short" , "medium", "long" ,"verylong"};
    public LoremIpsumClient(string variation)
    {
        if (possibleModifers.Contains(variation) == false) throw new ArgumentException("Invalid modifier variation");

        httpClient = new HttpClient();
        modifer = variation;
    } 
    
    public async Task<string> GetTextAsync()
    {
        try
        {
            var response = await httpClient.GetStringAsync($"https://loripsum.net/api/1/{modifer}/prude/plaintext");
            return response.Trim();
        }
        catch (HttpRequestException ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}