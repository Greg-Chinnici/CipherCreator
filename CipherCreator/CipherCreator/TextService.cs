namespace CipherCreator;

public class TextService
{
    private readonly ITextAPI textClient;
    public TextService(ITextAPI textClient) => this.textClient = textClient;

    public async Task<string> FetchString() => await textClient.GetTextAsync();
    
}