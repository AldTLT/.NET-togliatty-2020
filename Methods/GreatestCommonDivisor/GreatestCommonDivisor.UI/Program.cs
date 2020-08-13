using GreatestCommonDivisor.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor.UI
{
    class Program
    {
        /// <summary>
        /// Minimal amount of numbers to GCD calculate.
        /// </summary>
        const int minAmountToCalculate = 2;

        /// <summary>
        /// Maximal amount of numbers to GCD calculate. Depends on function.
        /// </summary>
        const int maxAmountToCalculate = 5;

        static void Main(string[] args)
        {
            Console.WriteLine(Messages.Title);
            Console.WriteLine(Messages.Intro);
            Console.WriteLine(Messages.Intro_Ignore);

            char[] separators = { ' ', ',' };

            var numbersString = Console.ReadLine();

            // Separate inserted string.
            var numbers = numbersString
                .Split(separators)
                .Select((stringNumber) =>
            {
                var parseOk = int.TryParse(stringNumber, out int number);

                int? numberToReturn = number;

                return parseOk ? numberToReturn : null;
            })
                .Where((number) => number != null)
                .Select((number) => (int)number)
                .ToArray();

            if (numbers.Length >= minAmountToCalculate && numbers.Length <= maxAmountToCalculate)
            {
                var gcdEuclidean = GetEuclideanGsd(numbers);
                Console.WriteLine($"{Messages.OutputEuclidean} {gcdEuclidean}");
                
                if (numbers.Length == minAmountToCalculate)
                {
                    var gcdBinary = GcdCalculate.Binary(numbers[0], numbers[1]);
                    Console.WriteLine($"{Messages.OutputBinary} {gcdBinary}");
                }
            }
            else
            {
                Console.WriteLine(Messages.EnterIncorrect);
            }

            Console.ReadKey();
        }

        private static int GetEuclideanGsd(int[] arrayNumbers)
        {
            switch (arrayNumbers.Length)
            {
                case 2:
                    {                       
                        return GcdCalculate.Euclidean(arrayNumbers[0], arrayNumbers[1]);
                    }
                case 3:
                    {
                        return GcdCalculate.Euclidean(arrayNumbers[0], arrayNumbers[1], arrayNumbers[2]);
                    }
                case 4:
                    {
                        return GcdCalculate.Euclidean(arrayNumbers[0], arrayNumbers[1], arrayNumbers[2], arrayNumbers[3]);
                    }
                case 5:
                    {
                        return GcdCalculate.Euclidean(arrayNumbers[0], arrayNumbers[1], arrayNumbers[2], arrayNumbers[4]);
                    }
                default:
                    {
                        throw new IndexOutOfRangeException();
                    }
            }
        } 
    }
}
