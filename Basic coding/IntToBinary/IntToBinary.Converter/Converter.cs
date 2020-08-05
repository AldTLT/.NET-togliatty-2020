using System;
using System.Text;

namespace IntToBinary.Converter
{
    /// <summary>
    /// The class represents methods of convertation from UInt32 to binary representation.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Method returns a binary representation of a UInt32 number in string format.
        /// </summary>
        /// <param name="sourceNumber">UInt32 number to convert.</param>
        /// <returns>Binary representation of the UInt32 number in string format.</returns>
        public static string ToBinaryCustom(this uint sourceNumber)
        {
            if (sourceNumber == 0)
            {
                return sourceNumber.ToString();
            }

            var resultContainer = new StringBuilder();

            while (sourceNumber > 0)
            {
                var bit = sourceNumber % 2;

                // Shift rigth for one bit.
                sourceNumber >>= 1;

                // Position to insert bit is 0.
                const int indexOfPosition = 0;

                // Number of digits to insert is 1.
                const int numberToInsert = 1;

                resultContainer.Insert(indexOfPosition, bit.ToString(), numberToInsert);
            }

            return resultContainer.ToString();
        }

        /// <summary>
        /// Method returns a binary representation of a UInt32 number.
        /// The method using standart classes and methods.
        /// </summary>
        /// <param name="sourceNumber">UInt32 number to convert.</param>
        /// <returns>Binary representation of the UInt32 number in string format.</returns>
        public static string ToBinaryStandart(this uint sourceNumber)
        {
            //The base of the return value for method Convert.ToString.
            const int baseOfConvert = 2;
            return Convert.ToString(sourceNumber, baseOfConvert);
        }
    }
}
