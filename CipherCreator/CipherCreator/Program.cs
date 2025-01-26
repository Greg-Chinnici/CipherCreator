

using CipherCreator;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("This program can Encrypt and Decrypt a string using a Caesar Cipher or a Scytale Cipher");
        Console.WriteLine("If you cant come up with a message to send, use the 'ipsum' command to get some");
        Console.WriteLine("shift in the context of the Skytale cipher is the number of turns on the pole");
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

    private static async Task<string> UseTextService(TextService service)
    {
        return await service.FetchString(); 
    }

    private static void UseCipher(string input, int shift)
    {
        string encodedCaesar = CaesarCipher.Encode(input, shift);
        Console.WriteLine($"Caesar Encoded string: {encodedCaesar}");
            
        string decodedCaesar = CaesarCipher.Decode(encodedCaesar, shift);
        Console.WriteLine($"Caesar Decoded string: {decodedCaesar}");    
        
        Console.WriteLine("Cracking the Caesar");
        Console.WriteLine(CaesarCipher.Crack(encodedCaesar , true));
        
        string encodedScytale = ScytaleCipher.Encode(input, shift);
        Console.WriteLine($"Scytale Encoded string: {encodedScytale}");
    }
}