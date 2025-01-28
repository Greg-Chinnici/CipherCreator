using System.Text;

namespace CipherCreator;
public class ScytaleCipher : IDecode, IEncode
{
    // https://en.wikipedia.org/wiki/Scytale
    // It is also known as the Caesar Box Cipher

    private static readonly char spacePlaceholder = ' ';
    public static string Encode(string input, int NumberOfTurns)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        
        int targetLength = ((input.Length + NumberOfTurns - 1) / NumberOfTurns) * NumberOfTurns; 
        input = input.PadRight(targetLength, ' ');
        
        List<char[]> rows = new List<char[]>();
        for (int i = 0; i < input.Length; i += NumberOfTurns)
        {
            var v = input.Substring(i, NumberOfTurns);
            rows.Add(v.ToCharArray());
        }
        
        StringBuilder sb = new(input.Length);
        
        for (int turn = 0; turn < NumberOfTurns; turn++)
            foreach (var row in rows)
            {
                char toAdd = row[turn];
                sb.Append(toAdd == ' ' ? spacePlaceholder : toAdd );
            }
        
        return sb.ToString();
    }

    public static string Decode(string input, int NumberOfTurns)
    {
        List<char[]> rows = new List<char[]>();
        for (int i = 0; i < input.Length; i+= input.Length / NumberOfTurns)
        {
            var v = input.Substring(i, input.Length / NumberOfTurns );
            rows.Add(v.ToCharArray());
        }
        
        StringBuilder sb = new();
        
        for(int col = 0; col < rows[0].Length; col++)
            foreach (char[] row in rows)
            {
                char toAdd = row[col];
                sb.Append(toAdd == spacePlaceholder ? ' ' : toAdd);
            }
        
        return sb.ToString().TrimEnd();
    }
}