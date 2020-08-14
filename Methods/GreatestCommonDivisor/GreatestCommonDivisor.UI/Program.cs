using GreatestCommonDivisor.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor.UI
{
    /// <summary>
    /// The main class of this application.
    /// </summary>
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

        /// <summary>
        /// The main method of this applicvation.
        /// </summary>
        static void Main()
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
                var gcdEuclidean = 0;
                var executionTime = new TimeSpan();

                switch (numbers.Length)
                {
                    case 2:
                        {
                            gcdEuclidean = GcdCalculate.GetEuclideanWatch(numbers[0], numbers[1], out executionTime);
                            break;
                        }
                    case 3:
                        {
                            gcdEuclidean = GcdCalculate.GetEuclidean(numbers[0], numbers[1], numbers[2]);
                            break;
                        }
                    case 4:
                        {
                            gcdEuclidean = GcdCalculate.GetEuclidean(numbers[0], numbers[1], numbers[2], numbers[3]);
                            break;
                        }
                    case 5:
                        {
                            gcdEuclidean = GcdCalculate.GetEuclidean(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
                            break;
                        }
                    default:
                        {
                            throw new IndexOutOfRangeException();
                        }
                }

                Console.WriteLine($"\n{Messages.OutputEuclidean} {gcdEuclidean}");

                if (numbers.Length == 2)
                {
                    Console.WriteLine($"{Messages.OutputExecutionTime} {executionTime}");
                }
                

                if (numbers.Length == minAmountToCalculate)
                {
                    var gcdBinary = GcdCalculate.GetBinaryWatch(numbers[0], numbers[1], out executionTime);
                    Console.WriteLine($"\n{Messages.OutputBinary} {gcdBinary}");
                    Console.WriteLine($"{Messages.OutputExecutionTime} {executionTime}");
                }
            }
            else
            {
                Console.WriteLine(Messages.EnterIncorrect);
            }

            Console.ReadKey();
        }
    }
}
