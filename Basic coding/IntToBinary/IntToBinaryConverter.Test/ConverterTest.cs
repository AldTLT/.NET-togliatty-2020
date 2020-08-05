using System;
using IntToBinary.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntToBinaryConverter.Test
{
    [TestClass]
    public class ConverterTest
    {
        /// <summary>
        /// The test of ToBinaryCustom method. The ones convert UInt32 to binary string format.
        /// </summary>
        /// <param name="valueToConvert">UInt32 value to convert.</param>
        /// <param name="expectedBinaryValue">Expected binary of converted value.</param>
        [DataTestMethod]
        [DataRow((uint)0, "0")]
        [DataRow((uint)2, "10")]
        [DataRow(uint.MaxValue, "11111111111111111111111111111111")]
        [DataRow(uint.MinValue, "0")]
        [DataRow((uint)3455, "110101111111")]
        [DataRow((uint)94395803, "101101000000101110110011011")]
        public void ToBinaryCustom_BinaryRepresentation_Test(uint valueToConvert, string expectedBinaryValue)
        {
            var binaryValue = valueToConvert.ToBinaryCustom();

            Assert.AreEqual(expectedBinaryValue, binaryValue);
        }

        /// <summary>
        /// The test of ToBinaryStandart method. The ones convert UInt32 to binary string format.
        /// </summary>
        /// <param name="valueToConvert">UInt32 value to convert.</param>
        /// <param name="expectedBinaryValue">Expected binary of converted value.</param>
        [DataTestMethod]
        [DataRow((uint)0, "0")]
        [DataRow((uint)2, "10")]
        [DataRow(uint.MaxValue, "11111111111111111111111111111111")]
        [DataRow(uint.MinValue, "0")]
        [DataRow((uint)3455, "110101111111")]
        [DataRow((uint)94395803, "101101000000101110110011011")]
        public void ToBinaryStandart_BinaryRepresentation_Test(uint valueToConvert, string expectedBinaryValue)
        {
            var binaryValue = valueToConvert.ToBinaryStandart();

            Assert.AreEqual(expectedBinaryValue, binaryValue);
        }
    }
}
