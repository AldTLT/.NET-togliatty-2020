using IntToBinary.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToBinary.UI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Messages.Title);
            Console.Write($"\n{Messages.Intro} ");

            uint numberToConvert;

            do
            {
                var numberString = Console.ReadLine();
                var parseResult = UInt32.TryParse(numberString, out numberToConvert);

                if (parseResult)
                {
                    break;
                }

                Console.WriteLine(Messages.IncorrectNumber);
            }
            while (true);

            var binaryCustom = numberToConvert.ToBinaryCustom();
            var binaryStandart = numberToConvert.ToBinaryStandart();

            Console.WriteLine($"\n{Messages.BinaryOutCustom} {binaryCustom}");
            Console.WriteLine($"\n{Messages.BinaryOutStandart} {binaryStandart}");

            Console.ReadKey();
        }
    }
}
