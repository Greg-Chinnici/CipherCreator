namespace CipherCreator;
public class ScytaleCipher : IEncode , IDecode
{
    // https://en.wikipedia.org/wiki/Scytale

    public static string Encode(string input, int width)
    {
        if (input.Length % width != 0)
            input = input.PadRight(input.Length + (input.Length % width), ' ');
        
        List<char[]> rows = new List<char[]>();
        for (int i = 0; i < input.Length-1; i += width)
        {
            var v = input.Substring(i, width ).ToCharArray();
            rows.Add(v.ToArray());
        }
        
        // h , e , l
        // l , o ,' '
        
        return string.Empty;
    }

    public static string Decode(string input, int width)
    {
        throw new NotImplementedException();
    }
}