namespace CipherCreator.Tests;
using CipherCreator;


public class ExternalAPITest
{
    public static IEnumerable<object[]> TextAPIClients()
    {
        yield return new object[] { new RonSwansonClient() };
        yield return new object[] { new DadJokeClient() };
        yield return new object[] { new LoremIpsumClient("short") };
        yield return new object[] { new LoremIpsumClient("long") };
    }
    
    [Theory(Skip = "Works fine, each one will catch exceptions and return a Error Message")]
    [MemberData(nameof(TextAPIClients))]
    public async void TextServiceTestNotNull(ITextAPI client)
    {
        TextService service = new TextService(client);
        
        string result = await service.FetchString();
        
        Assert.NotNull(result);
    }
}