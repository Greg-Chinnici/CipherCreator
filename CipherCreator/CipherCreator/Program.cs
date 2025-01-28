

using CipherCreator;

class Program
{
    public static async Task Main(string[] args)
    {
        
        Console.WriteLine("This program can Encrypt and Decrypt a string using a Caesar Cipher or a Scytale Cipher");
        Console.WriteLine("If you cant come up with a message to send, use the 'ipsum' command to get some");
        Console.WriteLine("shift in the context of the Scytale cipher is the number of turns around the pole");
        Console.WriteLine("These are 2 early versions of Cryptography: Substitution and Transposition");
        Console.WriteLine("=======================================================================================");
        
        TextService LoremIpsum = new TextService(new LoremIpsumClient("medium"));
        TextService DadJokes = new TextService(new DadJokeClient());
        TextService RonSwansonQuotes = new TextService(new RonSwansonClient());
        
        TextService[] services = { LoremIpsum, DadJokes, RonSwansonQuotes };
        
        while (true)
        {
            Console.Write("Enter a string to encode (or type 'quit' to exit, or type 'ipsum' for some text): ");
            string input = Console.ReadLine();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            int shift;
            while (true)
            {
                Console.Write("Enter a shift number (integer): ");
                string shiftInput = Console.ReadLine();

                if (int.TryParse(shiftInput, out shift))
                    break; 
                else
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            if (input.Equals("ipsum", StringComparison.OrdinalIgnoreCase))
            {
                Random random = new Random();
                input = await UseTextService(services[random.Next(services.Length)]);
            }
            
            UseCipher(input , shift);
        }
    }

    private static async Task<string> UseTextService(TextService service) => await service.FetchString(); 
    

    private static void UseCipher(string input, int shift)
    {
        Console.WriteLine($"Cipher Input: {input}");
        UseCaesar(input , shift);
        UseScytale(input , shift);
    }

    private static void UseCaesar(string input, int shift)
    {
        string encodedCaesar = CaesarCipher.Encode(input, shift);
        Console.WriteLine($"\nCaesar Encoded string: {encodedCaesar}");
        
        Console.WriteLine("\nCracking Caesar...");
        Console.WriteLine(CaesarCipher.Crack(encodedCaesar,true));
    }

    private static void UseScytale(string input, int turns)
    {
        string encodedScytale = ScytaleCipher.Encode(input, turns);
        Console.WriteLine($"\nScytale Encoded string: {encodedScytale}");
        
        string decodedScytale = ScytaleCipher.Decode(encodedScytale, turns);
        Console.WriteLine($"\nScytale Decoded string: {decodedScytale}");
    }
}