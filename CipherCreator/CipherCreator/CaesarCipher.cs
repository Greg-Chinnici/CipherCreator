
using System.Text;
using CipherCreator;

public class CaesarCipher : IDecode, IEncode
{

    public static string Encode(string input, int shift , bool shiftNumbers = false)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        if (shift == 0) return input;

        StringBuilder sb = new();
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char start = char.IsUpper(c) ? 'A' : 'a';
                int offset = c - start;
                int shifted = (offset + shift) % 26;
                if (shifted < 0) shifted += 26;
                char chr = (char)(shifted + start);

                sb.Append(chr);
            }
            else if (char.IsDigit(c) && shiftNumbers)
            {
                int number = int.Parse(c.ToString()) + 20; // So it wont go negative ever

                sb.Append((number + (shift % 10)) % 10);
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
    
    public static string Decode(string input, int shift) => Encode(input, -shift);

#region Crack
    private static readonly Dictionary<char, double> frequencies = new() {
        { 'E', 12.70 }, { 'T', 9.06 }, { 'A', 8.17 }, { 'O', 7.51 }, { 'I', 6.97 }, 
        { 'N', 6.75 }, { 'S', 6.33 }, { 'H', 6.09 }, { 'R', 5.99 }, { 'D', 4.25 }, 
        { 'L', 4.03 }, { 'C', 2.78 }, { 'U', 2.76 }, { 'M', 2.41 }, { 'W', 2.36 }, 
        { 'F', 2.23 }, { 'G', 2.02 }, { 'Y', 1.97 }, { 'P', 1.93 }, { 'B', 1.49 }, 
        { 'V', 0.98 }, { 'K', 0.77 }, { 'X', 0.15 }, { 'J', 0.15 }, { 'Q', 0.10 }, 
        { 'Z', 0.07 }
    };

    public static string Crack(string encodedText)
    {
        double bestDifference = double.MaxValue;
        int bestShift = int.MaxValue;
        
        foreach (int shift in Enumerable.Range(0, 26))
        {
           string decodedText = Decode(encodedText, shift);

           var percents = decodedText
               .Where(c => char.IsLetter(c))
               .Select(c => char.ToUpper(c))
               .GroupBy(c => c)
               .Select( g => new
                   {
                       letter = g.Key , 
                       percent = ((double)g.Count() / decodedText.Count(c => char.IsLetter(c))) * 100
                   }
               ).ToDictionary(x=>x.letter,x=>x.percent);
           
           
           double totalAbsoluteDifference = frequencies
               .Sum(f => Math.Abs(f.Value - (percents.ContainsKey(f.Key) ? percents[f.Key] : 0)));
           
           Console.WriteLine($"shift {shift}: {totalAbsoluteDifference} total absolute difference");

           if (totalAbsoluteDifference < bestDifference)
           {
               bestDifference = totalAbsoluteDifference;
               bestShift = shift;
           }

        }
        Console.WriteLine($"Best shift is {bestShift} with {bestDifference:00.00} difference.");
        
        return Decode(encodedText, bestShift);
    }
 #endregion   
    
}