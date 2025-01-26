namespace CipherCreator.Tests;

public class ScytaleCipherTest
{
    
    [Theory]
    [InlineData("iamhurtverybadlyhelp", 5, "iryyatbhmvaehedlurlp")]
    [InlineData("" , 5 , "")]
    [InlineData(null , 0 , "")]
    [InlineData("ABCDE", 5 , "ABCDE")]
    [InlineData("ski mask the slump dog dr suess", 6 , "ss__rskksd__i_los__tugu_mhm_e_aepds_")]
    [InlineData("Lazer Dim 7000" , 3, "LeD_0ari70z_m0_")]
    public void ScytaleEncodeTest(string input, int nTurns, string expected)
    {
        string output = ScytaleCipher.Encode(input, nTurns);
        Assert.Equal(expected, output);
    }


    [Theory]
    [InlineData( "iryyatbhmvaehedlurlp",5, "iamhurtverybadlyhelp")]
    public void ScytaleDecodeTest(string input, int nTurns, string expected)
    {
        string output = ScytaleCipher.Decode(input, nTurns);
        Assert.Equal(expected, output);
    }
}