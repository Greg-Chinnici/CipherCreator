

using CipherCreator;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine(CaesarCipher.Crack("Xli ibxirhih evq wepyxmrk kiwxyvi aew eppikih xs fi fewih sr er ergmirx Vsqer\ngywxsq, fyx rs orsar Vsqer asvo sj evx hitmgxw mx, rsv hsiw erc ibxerx Vsqer xibx\nhiwgvmfi mx. Lmwxsvmerw lezi mrwxieh hixivqmrih xlex xli kiwxyvi svmkmrexih jvsq\nNeguyiw-Psymw Hezmh'w 1784 temrxmrk Sexl sj xli Lsvexmm, almgl hmwtpecih e\nvemwih evq wepyxexsvc kiwxyvi mr er ergmirx Vsqer wixxmrk. Xli kiwxyvi erh mxw\nmhirxmjmgexmsr amxl ergmirx Vsqi aew ehzergih mr sxliv Jvirgl risgpewwmg evx"));
        Console.WriteLine(CaesarCipher.Crack("Ild spnh ephhts xc iwxh bpcctg qtudgt wt lph pqat id hetpz, pcs X duitc\nutpgts iwpi wxh hjuutgxcvh wps stegxkts wxb du jcstghipcsxcv. Lwtc wt\nwps xc hdbt btphjgt gtrdktgts, X gtbdkts wxb id bn dlc rpqxc pcs\npiitcsts dc wxb ph bjrw ph bn sjin ldjas etgbxi. X ctktg hpl p bdgt\nxcitgthixcv rgtpijgt: wxh tnth wpkt vtctgpaan pc tmegthhxdc du\nlxascthh, pcs tktc bpscthh, qji iwtgt pgt bdbtcih lwtc, xu pcndct\netgudgbh pc pri du zxcscthh idlpgsh wxb dg sdth wxb pcn iwt bdhi\nigxuaxcv htgkxrt, wxh lwdat rdjcitcpcrt xh axvwits je, ph xi ltgt, lxiw\np qtpb du qtctkdatcrt pcs hltticthh iwpi X ctktg hpl tfjpaats. Qji wt\nxh vtctgpaan btapcrwdan pcs sthepxgxcv, pcs hdbtixbth wt vcphwth wxh\nittiw, ph xu xbepixtci du iwt ltxvwi du ldth iwpi deegthhth wxb"));

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
}