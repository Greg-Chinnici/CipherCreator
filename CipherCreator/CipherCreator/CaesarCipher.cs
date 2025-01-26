
using System.Text;
using CipherCreator;

public class CaesarCipher : IDecode, IEncode
{
# region Encode/Decode
    public static string Encode(string input, int shift , bool shiftNumbers)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;
        if (shift % 26 == 0) return input;

        StringBuilder output = new();
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                output.Append(shiftLetter(c, shift));
            }
            else if (char.IsDigit(c) && shiftNumbers)
            {
                output.Append(shiftDigit(c, shift));
            }
            else
            {
                output.Append(c);
            }
        }

        return output.ToString();
    }

    public static string Encode(string input, int shift)
    {
        return Encode(input , shift , false); 
    }


    private static char shiftLetter(char letter, int shift)
    {
        char start = char.IsUpper(letter) ? 'A' : 'a';
        int offset = letter - start;
        int shifted = (offset + shift) % 26;
        if (shifted < 0) shifted += 26;

        return (char)(shifted + start);
    }

    private static int shiftDigit(char digit, int shift)
    {
        int number = int.Parse(digit.ToString()) + 20; // So it wont go negative ever
        
        return (number + (shift % 10)) % 10;
    }
    
    public static string Decode(string input, int shift) => Encode(input, -shift);

#endregion

#region Crack
    private static readonly Dictionary<char, double> frequencies = new() {
        { 'E', 12.70}, { 'T', 9.06 }, { 'A', 8.17 }, { 'O', 7.51 }, { 'I', 6.97 }, 
        { 'N', 6.75 }, { 'S', 6.33 }, { 'H', 6.09 }, { 'R', 5.99 }, { 'D', 4.25 }, 
        { 'L', 4.03 }, { 'C', 2.78 }, { 'U', 2.76 }, { 'M', 2.41 }, { 'W', 2.36 }, 
        { 'F', 2.23 }, { 'G', 2.02 }, { 'Y', 1.97 }, { 'P', 1.93 }, { 'B', 1.49 }, 
        { 'V', 0.98 }, { 'K', 0.77 }, { 'X', 0.15 }, { 'J', 0.15 }, { 'Q', 0.10 }, 
        { 'Z', 0.07 }
    };

    // Only works correctly if the input text is encoded from english and at least a few words long
    public static string Crack(string encodedText , bool showProgress= false)
    {
        double bestDifference = double.MaxValue;
        int bestShift = int.MaxValue;
        
        foreach (int shift in Enumerable.Range(0, 26))
        {
           string decodedText = Decode(encodedText, shift);
           
           Dictionary<char,double> percents = frequenciesByLetter(decodedText);
           
           double totalAbsoluteDifference = absoluteDifference(percents);
           
           if (showProgress) Console.WriteLine($"shift {shift} or {26-shift}: {totalAbsoluteDifference} total absolute difference");

           if (totalAbsoluteDifference < bestDifference)
           {
               bestDifference = totalAbsoluteDifference;
               bestShift = shift;
           }

        }
        Console.WriteLine($"Best shift is {bestShift} with a {bestDifference:00.00} difference.");
        
        return Decode(encodedText, bestShift);
    }

    private static Dictionary<char, double> frequenciesByLetter(string decodedText)
    {
        
        return decodedText
            .Where(c => char.IsLetter(c))
            .Select(c => char.ToUpper(c))
            .GroupBy(c => c)
            .Select( g => new
                {
                    letter = g.Key , 
                    percent = ((double) g.Count() / decodedText.Count(c => char.IsLetter(c))) * 100
                }
            ).ToDictionary(x=> x.letter , x=> x.percent);
    }

    private static double absoluteDifference(Dictionary<char,double> percents)
    {
        
        return frequencies
            .Sum(f => Math.Abs(f.Value - (percents.ContainsKey(f.Key) ? percents[f.Key] : 0)));
    }
#endregion   
    
}