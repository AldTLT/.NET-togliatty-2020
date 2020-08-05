using IntToBinary.Converter;
using System;

namespace IntToBinary.UI
{
    /// <summary>
    /// The main class of the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method of the application.
        /// </summary>
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
