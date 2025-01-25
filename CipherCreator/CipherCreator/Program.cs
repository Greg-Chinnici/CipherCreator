

using CipherCreator;

class Program
{
    public static async Task Main(string[] args)
    {

        //Console.WriteLine(CaesarCipher.Crack("Xli ibxirhih evq wepyxmrk kiwxyvi aew eppikih xs fi fewih sr er ergmirx Vsqer\ngywxsq, fyx rs orsar Vsqer asvo sj evx hitmgxw mx, rsv hsiw erc ibxerx Vsqer xibx\nhiwgvmfi mx. Lmwxsvmerw lezi mrwxieh hixivqmrih xlex xli kiwxyvi svmkmrexih jvsq\nNeguyiw-Psymw Hezmh'w 1784 temrxmrk Sexl sj xli Lsvexmm, almgl hmwtpecih e\nvemwih evq wepyxexsvc kiwxyvi mr er ergmirx Vsqer wixxmrk. Xli kiwxyvi erh mxw\nmhirxmjmgexmsr amxl ergmirx Vsqi aew ehzergih mr sxliv Jvirgl risgpewwmg evx"));

        ScytaleCipher.Encode("hello", 3);
        return;
        
        TextService LoremIpsum = new TextService(new LoremIpsumClient());
        TextService[] services = { LoremIpsum };
        
        foreach (var service in services)
            await UseTextService(service);

        return;
        
        while (true)
        {
            Console.Write("Enter a string to encode (or type 'quit' to exit): ");
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

            string encoded = CaesarCipher.Encode(input, shift);
            Console.WriteLine($"Encoded string: {encoded}");
            
            string decoded = CaesarCipher.Decode(encoded, shift);
            Console.WriteLine($"Decoded string: {decoded}");
        }
    }


    public static async Task UseTextService(TextService service)
    {
        string normal = await service.FetchString();
        
        Console.WriteLine(normal);
        
        string encoded_lorem = CaesarCipher.Encode(normal, 8);
        
        Console.WriteLine(encoded_lorem);
        //Console.WriteLine(CaesarCipher.Decode(encoded_lorem , 8));
        Console.WriteLine(CaesarCipher.Crack(encoded_lorem));

    }
}