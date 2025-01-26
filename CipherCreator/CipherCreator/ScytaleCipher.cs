using System.Text;

namespace CipherCreator;
public class ScytaleCipher : IEncode , IDecode
{
    // https://en.wikipedia.org/wiki/Scytale
    // It is also known as the Caesar Box Cipher

    private static readonly char spacePlaceholder = '_';
    public static string Encode(string input, int NumberOfTurns)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        
        if (input.Length % NumberOfTurns != 0)
            input = input.PadRight(input.Length + (NumberOfTurns - input.Length % NumberOfTurns), ' ');
        
        List<char[]> rows = new List<char[]>();
        for (int i = 0; i < input.Length; i += NumberOfTurns)
        {
            var v = input.Substring(i, NumberOfTurns ).ToCharArray();
            rows.Add(v);
        }
        
        StringBuilder sb = new();
        foreach (int i in Enumerable.Range(0, NumberOfTurns))
            foreach (int j in Enumerable.Range(0, rows.Count))
            {
                char toAdd = rows[j][i];
                sb.Append(toAdd == ' ' ? spacePlaceholder : toAdd );
            }
        
        return sb.ToString();
    }

    public static string Decode(string input, int NumberOfTurns)
    {
        List<char[]> rows = new List<char[]>();
        for (int i = 0; i < input.Length; i += NumberOfTurns)
        {
            var v = input.Substring(i, NumberOfTurns ).ToCharArray();
            rows.Add(v);
        }
        
        return string.Empty;
    }
}