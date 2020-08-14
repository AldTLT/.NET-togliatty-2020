using System;
using System.Diagnostics;

namespace GreatestCommonDivisor.Calculate
{
    /// <summary>
    /// The partial class represents methods of execution time of GCD calculation.
    /// </summary>
    public static partial class GcdCalculate
    {
        /// <summary>
        /// The method returns GCD using Euclidean algorithm and outs execution time of calculation.
        /// </summary>
        /// <param name="firstNumber">First number to GCD calculate.</param>
        /// <param name="secondNumber">Second number to GCD calculate.</param>
        /// <param name="executionTime">Execution time of GCD calculation.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int GetEuclideanWatch(int firstNumber, int secondNumber, out TimeSpan executionTime)
        {
            var watch = new Stopwatch();
            watch.Start();

            var gcdEuclidean = GcdCalculate.GetGcdEuclidean(firstNumber, secondNumber);

            watch.Stop();
            executionTime = watch.Elapsed;

            return gcdEuclidean;
        }

        /// <summary>
        /// The method returns GCD using Binary algorithm and outs execution time of calculation.
        /// </summary>
        /// <param name="firstNumber">First number to GCD calculate.</param>
        /// <param name="secondNumber">Second number to GCD calculate.</param>
        /// <param name="executionTime">Execution time of GCD calculation.</param>
        /// <returns>Greatest common divisor.</returns>
        public static int GetBinaryWatch(int firstNumber, int secondNumber, out TimeSpan executionTime)
        {
            var watch = new Stopwatch();
            watch.Start();

            var gcdEuclidean = GcdCalculate.GetGcdBinary(firstNumber, secondNumber);

            watch.Stop();
            executionTime = watch.Elapsed;

            return gcdEuclidean;
        }
    }
}
