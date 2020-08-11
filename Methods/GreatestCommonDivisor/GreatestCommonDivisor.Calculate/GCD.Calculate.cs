using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor.Calculate
{
    /// <summary>
    /// The class represents methods of greatest common divisor calculate.
    /// </summary>
    public static class GcdCalculate
    {
        // Minimum number of values to GCD calculate. 
        private const int minValueNumber = 2;

        // Minimum size of value to GCD calculate.
        private const int minValueToCalculate = 1;

        /// <summary>
        /// The method returns greatest common divisor of two Int32 numbers using Euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number to GCD calculate.</param>
        /// <param name="secondNumber">Second number to GCD calculate.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int Euclidean(int firstNumber, int secondNumber)
        {
            return GetGcdEuclidean(firstNumber, secondNumber);
        }

        /// <summary>
        /// The method returns greatest common divisor of three Int32 numbers using Euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number to GCD calculate.</param>
        /// <param name="secondNumber">Second number to GCD calculate.</param>
        /// <param name="thirdNumber">Third number to GCD calculate.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int Euclidean(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GetGcdEuclidean(firstNumber, secondNumber, thirdNumber);
        }

        /// <summary>
        /// The method returns greatest common divisor of four Int32 numbers using Euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number to GCD calculate.</param>
        /// <param name="secondNumber">Second number to GCD calculate.</param>
        /// <param name="thirdNumber">Third number to GCD calculate.</param>
        /// <param name="fourthNumber">Fourth number to GCD calculate.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int Euclidean(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            return GetGcdEuclidean(firstNumber, secondNumber, thirdNumber, fourthNumber);
        }

        /// <summary>
        /// The method returns greatest common divisor of five Int32 numbers using Euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number to GCD calculate.</param>
        /// <param name="secondNumber">Second number to GCD calculate.</param>
        /// <param name="thirdNumber">Third number to GCD calculate.</param>
        /// <param name="fourthNumber">Fourth number to GCD calculate.</param>
        /// <param name="fifthNumber">Fifth number to GCD calculate.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int Euclidean(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber)
        {
            return GetGcdEuclidean(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber);
        }

        /// <summary>
        /// The method returns the greatest common divisor of two or more Int32 numbers using Euclidean algorithm.
        /// The method calculates GCD using Euclidean algorithm.
        /// </summary>
        /// <param name="numbers">Numbers to calculate.</param>
        /// <returns>Greatest common divisor of the numbers.</returns>
        private static int GetGcdEuclidean(params int[] numbers)
        {
            if (numbers.Length < minValueNumber)
            {
                throw new ArgumentException(Messages.Exception_MinQuantity);
            }

            var listOfNumbers = numbers.ToList();

            listOfNumbers = listOfNumbers
                .Select(element => Math.Abs(element))
                .Where(element => element != 0)
                .ToList();

            while (listOfNumbers.Count > 1)
            {
                var minElement = listOfNumbers.Min();

                listOfNumbers = listOfNumbers
                    .Select(element => element - minElement)
                    .Where(element => element != 0)
                    .ToList();

                // Return 1 if one of the remaining numbers is 1.
                if (minElement == minValueToCalculate)
                {
                    return minValueToCalculate;
                }

                listOfNumbers.Add(minElement);
            }

            // If the NOD of zeros is searched, return zero.
            if (listOfNumbers.Count == 0)
            {
                return 0;
            }
            return listOfNumbers.First();
        }

        /// <summary>
        /// The method returns the greatest common divisor of two Int32 numbers.
        /// The method calculates GCD using binary (Stein's) algorithm.
        /// </summary>
        /// <param name="numbers">Numbers to calculate.</param>
        /// <returns>Greatest common divisor of the numbers.</returns>
        private static int GetGcdBinary(params int[] numbers)
        {
            if (numbers.Length < minValueNumber)
            {
                throw new ArgumentException(Messages.Exception_MinQuantity);
            }

            var listOfNumbers = numbers.ToList();

            listOfNumbers = listOfNumbers
                .Select(element => Math.Abs(element))
                .Where(element => element != 0)
                .ToList();

            var degree = 0;

            int minElement = listOfNumbers.Min();

            while (listOfNumbers.Count > 1 && !listOfNumbers.All(element => element == minElement))
            {
                if (listOfNumbers.All(element => (element & 1) == 0))
                {
                    degree++;
                }

                listOfNumbers = listOfNumbers
                .Select(element => (element & 1) == 0 ? element >> 1 : element)
                .Where(number => number > 0)
                .ToList();

                if (listOfNumbers.All(element => (element & 1) != 0))
                {
                    minElement = listOfNumbers.Min();

                    listOfNumbers = listOfNumbers
                        .Select(number => (number - minElement) / 2)
                        .Where(number => number > 0)
                        .ToList();

                    listOfNumbers.Add(minElement);
                }
            }

            // If the NOD of zeros is searched, return zero
            if (listOfNumbers.Count == 0)
            {
                return 0;
            }

            return (int)Math.Pow(2, degree) * listOfNumbers.First();
        }
    }
}
