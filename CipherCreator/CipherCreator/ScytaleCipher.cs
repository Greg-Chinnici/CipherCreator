using System.Text;

namespace CipherCreator;
public class ScytaleCipher : IEncode , IDecode
{
    // https://en.wikipedia.org/wiki/Scytale

    public static string Encode(string input, int NumberOfTurns)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        
        if (input.Length % NumberOfTurns != 0)
            input = input.PadRight(input.Length + (NumberOfTurns - input.Length % NumberOfTurns), ' ');
        
        List<char[]> rows = new List<char[]>();
        for (int i = 0; i < input.Length; i += NumberOfTurns)
        {
            var v = input.Substring(i, NumberOfTurns ).ToCharArray();
            rows.Add(v.ToArray());
        }
        
        StringBuilder sb = new();
        for (int i = 0; i < NumberOfTurns ; i++)
        {
            for (int j = 0; j < rows.Count; j++)
            {
                char toAdd = rows[j][i];
                sb.Append(toAdd == ' ' ? '_' : toAdd );
            }
        }
        
        return sb.ToString();
    }

    public static string Decode(string input, int width)
    {
        throw new NotImplementedException();
    }
}