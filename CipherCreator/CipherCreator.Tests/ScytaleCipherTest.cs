namespace CipherCreator.Tests;

public class ScytaleCipherTest
{
    
    [Theory]
    [InlineData("iamhurtverybadlyhelp", 5, "iryyatbhmvaehedlurlp")]
    [InlineData("" , 5 , "")]
    [InlineData(null , 0 , "")]
    [InlineData("ABCDE", 5 , "ABCDE")]
    [InlineData("ski mask the slump dog dr suess", 6 , "ss  rskksd  i los  tugu mhm e aepds ")]
    [InlineData("Lazer Dim 7000" , 3, "LeD 0ari70z m0 ")]
    public void ScytaleEncodeTest(string input, int nTurns, string expected)
    {
        string output = ScytaleCipher.Encode(input, nTurns);
        Assert.Equal(expected, output);
    }


    [Theory]
    [InlineData( "iryyatbhmvaehedlurlp",5, "iamhurtverybadlyhelp")]
    [InlineData("mairymsenegg" , 3 , "mynameisgreg")]
    [InlineData("t wti#hiren isin  s t c ",4,"this is written in c#")]
    public void ScytaleDecodeTest(string input, int nTurns, string expected)
    {
        string output = ScytaleCipher.Decode(input, nTurns);
        Assert.Equal(expected, output);
    }
}