using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRoot.Calculation;

namespace NRootCalculation.Test
{
    /// <summary>
    /// The class represents test of calculation methods.
    /// </summary>
    [TestClass]
    public class GetDecimalPlaceTest
    {
        /// <summary>
        /// The test of GetDecimalPlace method. The method checks number of digits after comma of source numbers.
        /// </summary>
        /// <param name="valueToCheck">Value to check of number of digits.</param>
        /// <param name="expectedDecimalPlace">Expected number of digits after comma of source number.</param>
        [DataTestMethod]
        [DataRow(0.01, 2)]
        [DataRow(0.006, 3)]
        [DataRow(0.0002, 4)]
        [DataRow(0.00009, 5)]
        [DataRow(0.000005, 6)]
        [DataRow(0.0000004, 7)]
        public void NRoot_Accuracy_NumberOfDigitsAfterComma_Test(double valueToCheck, int expectedDecimalPlace)
        {
            var calculatedDecimalPlace = Calculation.GetDecimalPlace(valueToCheck);

            Assert.AreEqual(expectedDecimalPlace, calculatedDecimalPlace);
        }
    }
}
