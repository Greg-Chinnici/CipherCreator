namespace CipherCreator;

public class TextService
{
    private readonly ITextAPI textClient;
    public TextService(ITextAPI _textClient) => textClient = _textClient;

    public async Task<string> FetchString()
    {
        string text = await textClient.GetTextAsync();
        return text;
    }
}