using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRoot.Calculation;

namespace NRootCalculation.Test
{
    /// <summary>
    /// The class represents test of N-root calculation class.
    /// </summary>
    [TestClass]
    public class NRootTest
    {
        /// <summary>
        /// The test of positive number n-root calculate.
        /// </summary>
        /// <param name="numberToCalculate">Number to calculate n-root.</param>
        /// <param name="root">Root value.</param>
        /// <param name="accuracy">Accuracy of finding the number.</param>
        /// <param name="expectedNRoot">Expected N-root.</param>
        [DataTestMethod]
        [DataRow(4, 2, 0.01, 2)]
        [DataRow(8, 3, 0.001, 2)]
        [DataRow(0.0625, 4, 0.0001, 0.5)]
        [DataRow(14.6969, 1.5, 0.0001, 5.9999)]
        public void NRoot_PositiveNumberToCalculate_Test(double numberToCalculate, double root, double accuracy, double expectedNRoot)
        {
            var calculatedNRoot = numberToCalculate.GetNRoot(root, accuracy);

            Assert.AreEqual(expectedNRoot, calculatedNRoot);
        }

        /// <summary>
        /// The test of negative number n-root calculate.
        /// </summary>
        /// <param name="numberToCalculate">Number to calculate n-root.</param>
        /// <param name="root">Root value.</param>
        /// <param name="accuracy">Accuracy of finding the number.</param>
        /// <param name="expectedNRoot">Expected N-root.</param>
        [DataTestMethod]
        [DataRow(-8, 3, 0.001, -2)]
        [DataRow(-68719.476736, 5, 0.000001, -9.277179)]
        [DataRow(-823543, 7, 1, -7)]
        public void NRoot_NegativeNumberToCalculate_Test(double numberToCalculate, double root, double accuracy, double expectedNRoot)
        {
            var calculatedNRoot = numberToCalculate.GetNRoot(root, accuracy);

            Assert.AreEqual(expectedNRoot, calculatedNRoot);
        }

        /// <summary>
        /// The test of wrong value - accuracy is negative or zero.
        /// </summary>
        /// <param name="numberToCalculate">Number to calculate n-root.</param>
        /// <param name="root">Root value.</param>
        /// <param name="accuracy">Accuracy of finding the number.</param>
        [DataTestMethod]
        [DataRow(-8, 3, 0)]
        [DataRow(4, 2, 0)]
        [DataRow(-68719.476736, 5, -2)]
        [DataRow(-823543, 7, -0.1)]
        public void NRoot_NegativeOrZeroAccuracy_NaN_Test(double numberToCalculate, double root, double accuracy)
        {
            var calculatedNRoot = numberToCalculate.GetNRoot(root, accuracy);

            Assert.IsTrue(double.IsNaN(calculatedNRoot));
        }

        /// <summary>
        /// The test of wrong value - root is negative or zero.
        /// </summary>
        /// <param name="numberToCalculate">Number to calculate n-root.</param>
        /// <param name="root">Root value.</param>
        /// <param name="accuracy">Accuracy of finding the number.</param>
        [DataTestMethod]
        [DataRow(8, -2, 0.1)]
        [DataRow(4, -8.3, 0.01)]
        [DataRow(16, -1, 1)]
        public void NRoot_NegativeOrZeroRoot_NaN_Test(double numberToCalculate, double root, double accuracy)
        {
            var calculatedNRoot = numberToCalculate.GetNRoot(root, accuracy);

            Assert.IsTrue(double.IsNaN(calculatedNRoot));
        }
    }
}
