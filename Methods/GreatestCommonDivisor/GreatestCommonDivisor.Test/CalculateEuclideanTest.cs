using GreatestCommonDivisor.Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreatestCommonDivisor.Test
{
    /// <summary>
    /// The tests of greatest common divisor calculation using Euclidean algorithm.
    /// </summary>
    [TestClass]
    public class CalculateEuclideanTest
    {
        /// <summary>
        /// Test of Euclidean greatest common divisor algorithm for two numbers.
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
            var calculatedGcd = GcdCalculate.GetEuclidean(firstNumber, secondNumber);

            Assert.AreEqual(expectedGcd, calculatedGcd);
        }

        /// <summary>
        /// Test of Euclidean greatest common divisor algorithm for three numbers.
        /// </summary>
        /// <param name="expectedGCD">Expected GCD result.</param>
        /// <param name="firstNUmber">First number to calculate.</param>
        /// <param name="secondNumber">Second number to calculate.</param>
        /// <param name="thirdNumber">Third number to calculate.</param>
        [DataTestMethod]
        [DataRow(3, -183, 3489, -873243)]
        [DataRow(73, 45479, 5329, 365)]
        [DataRow(5, -5895, 35, -2345885)]
        [DataRow(1, 3455, 6768, 7)]
        [DataRow(435634, 0, -435634, 0)]
        [DataRow(83, 83, 0, 166)]
        public void Euclidean_GsdOfThreeNumber_Test(int expectedGcd, int firstNumber, int secondNumber, int thirdNumber)
        {
            var calculatedGcd = GcdCalculate.GetEuclidean(firstNumber, secondNumber, thirdNumber);

            Assert.AreEqual(expectedGcd, calculatedGcd);
        }

        /// <summary>
        /// Test of Euclidean greatest common divisor algorithm for four numbers.
        /// </summary>
        /// <param name="expectedGCD">Expected GCD result.</param>
        /// <param name="firstNUmber">First number to calculate.</param>
        /// <param name="secondNumber">Second number to calculate.</param>
        /// <param name="thirdNumber">Third number to calculate.</param>
        /// <param name="fourthNumber">Fourth number to GCD calculation.</param>
        [DataTestMethod]
        [DataRow(3, -183, 9, 3489, -873243)]
        [DataRow(73, 42997, 45479, 5329, 365)]
        [DataRow(5, 15, -5895, 35, -2345885)]
        [DataRow(1, 923407, 3455, 6768, 7)]
        [DataRow(435634, 0, 0, -435634, 0)]
        [DataRow(83, 83, 0, 166, 0)]
        public void Euclidean_GsdOfFourNumber_Test(int expectedGcd, int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            var calculatedGcd = GcdCalculate.GetEuclidean(firstNumber, secondNumber, thirdNumber, fourthNumber);

            Assert.AreEqual(expectedGcd, calculatedGcd);
        }

        /// <summary>
        /// Test of Euclidean greatest common divisor algorithm for five numbers.
        /// </summary>
        /// <param name="expectedGCD">Expected GCD result.</param>
        /// <param name="firstNUmber">First number to calculate.</param>
        /// <param name="secondNumber">Second number to calculate.</param>
        /// <param name="thirdNumber">Third number to calculate.</param>
        /// <param name="fourthNumber">Fourth number to GCD calculation.</param>
        /// <param name="fifthNumber">Fifth number to GCD calculation.</param>
        [DataTestMethod]
        [DataRow(3, -196560, -183, 9, 3489, -873243)]
        [DataRow(73, 42997, 146, 45479, 5329, 365)]
        [DataRow(5, -1324230, -15, -5890, -50, -2345885)]
        [DataRow(1, 923407, 3455, 6768, 7, 34595)]
        [DataRow(435634, 0, 0, -435634, 0, 0)]
        [DataRow(83, 83, 0, 332, 166, 0)]
        public void Euclidean_GsdOfFourNumber_Test(int expectedGcd, int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber)
        {
            var calculatedGcd = GcdCalculate.GetEuclidean(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber);

            Assert.AreEqual(expectedGcd, calculatedGcd);
        }
    }
}
