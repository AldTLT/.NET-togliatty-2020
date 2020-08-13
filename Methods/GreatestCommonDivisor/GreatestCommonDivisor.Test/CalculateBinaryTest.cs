using GreatestCommonDivisor.Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreatestCommonDivisor.Test
{
    /// <summary>
    /// The tests of greatest common divisor calculation using Euclidean algorithm.
    /// </summary>
    [TestClass]
    public class CalculateBinaryTest
    {
        /// <summary>
        /// Test of Binary greatest common divisor algorithm for two numbers.
        /// </summary>
        /// <param name="expectedGCD">Expected GCD result.</param>
        /// <param name="firstNUmber">First number to calculate.</param>
        /// <param name="secondNumber">Second number to calculate.</param>
        [DataTestMethod]
        [DataRow(3, -183, -873243)]
        [DataRow(73, 5329, 365)]
        [DataRow(5, -5895, 35)]
        [DataRow(1, 3455, 6768)]
        [DataRow(435634, 0, -435634)]
        [DataRow(83, 83, 0)]
        public void Euclidean_GsdOfTwoNumber_Test(int expectedGcd, int firstNumber, int secondNumber)
        {
            var calculatedGcd = GcdCalculate.Binary(firstNumber, secondNumber);

            Assert.AreEqual(expectedGcd, calculatedGcd);
        }
    }
}
