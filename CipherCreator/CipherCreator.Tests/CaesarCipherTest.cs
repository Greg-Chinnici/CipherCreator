namespace CipherCreator.Tests;

public class CaesarCipherTest
{
    [Theory]
    [InlineData("hello", 0, "hello")]
    [InlineData("hello", 13123, "axeeh")]
    [InlineData("reallysmallnumber", -33993, "gtpaanhbpaacjbqtg")]
    [InlineData("hello", 3, "khoor")]
    [InlineData("hello", -1, "gdkkn")]
    [InlineData("1234", 0, "1234")]
    [InlineData("1234", 1, "2345")]
    [InlineData("AbCdE", 1, "BcDeF")]
    [InlineData("123ABCabc", 1, "234BCDbcd")]
    [InlineData("123ABCabc", -1, "012ZABzab")]
    [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ",5,"FGHIJKLMNOPQRSTUVWXYZABCDE")]
    [InlineData("abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ" , 4 , "efghijklmnopqrstuvwxyzabcd5678901234EFGHIJKLMNOPQRSTUVWXYZABCD")]
    [InlineData("5ZdlyWJYPPiPyqf4wAcHF4OiIU" , 2 , "7BfnaYLARRkRash6yCeJH6QkKW")]
    [InlineData("5ZdlyWJYPPiPyqf4wAcHF4OiIU" , -2 , "3XbjwUHWNNgNwod2uYaFD2MgGS")]
    [InlineData("G7WSMjtdLwOSaycIqFeJzKXrpR", 17 ,"X4NJDakuCnFJrptZhWvAqBOigI")]
    [InlineData("G7WSMjtdLwOSaycIqFeJzKXrpR",-17 ,"P0FBVscmUfXBjhlRzOnSiTGayA")]
    [InlineData(null , 0 , "")]
    [InlineData("" , 13232 , "")]
    public void EncodeTestCaesar(string input , int rotation , string expected)
    {
        string output = CaesarCipher.Encode(input, rotation , true);
        
        Assert.Equal(expected, output);
    }


    [Theory]
    [InlineData("hello", 0, "hello")]
    [InlineData("ifmmp", 1, "hello")]
    public void DecodeTestCaesar(string input, int rotation, string expected)
    {
        string output = CaesarCipher.Decode(input, rotation);
        
        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("Ild spnh ephhts xc iwxh bpcctg qtudgt wt lph pqat id hetpz, pcs X duitc utpgts iwpi wxh hjuutgxcvh wps stegxkts wxb du jcstghipcsxcv. ", "Two days passed in this manner before he was able to speak, and I often feared that his sufferings had deprived him of understanding. ")]
    [InlineData(null , "")]
    [InlineData("","")]
    public void CrackTestCaesar(string input, string expected)
    {
        string output = CaesarCipher.Crack(input);
        
        Assert.Equal(expected, output);
    }
    
}