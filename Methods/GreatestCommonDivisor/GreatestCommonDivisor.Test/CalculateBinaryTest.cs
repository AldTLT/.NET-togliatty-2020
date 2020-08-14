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
        /// <param name="firstNUmber">First number to calculate.</param>
        /// <param name="secondNumber">Second number to calculate.</param>
        /// <param name="expectedGCD">Expected GCD result.</param>
        [DataTestMethod]
        [DataRow(-183, -873243, 3)]
        [DataRow(5329, 365, 73)]
        [DataRow(-5895, 35, 5)]
        [DataRow(3455, 6768, 1)]
        [DataRow(0, -435634, 435634)]
        [DataRow(83, 0, 83)]
        public void Euclidean_GsdOfTwoNumber_Test(int firstNumber, int secondNumber, int expectedGcd )
        {
            var calculatedGcd = GcdCalculate.GetBinary(firstNumber, secondNumber);

            Assert.AreEqual(expectedGcd, calculatedGcd);
        }
    }
}
