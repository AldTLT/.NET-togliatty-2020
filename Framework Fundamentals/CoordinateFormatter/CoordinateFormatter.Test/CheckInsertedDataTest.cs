using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoordinateFormatter.Test
{
    /// <summary>
    /// The class represents tests of inserted data.
    /// </summary>
    [TestClass]
    public class CheckInsertedDataTest
    {
        /// <summary>
        /// The test checks if a coordinate is correct.
        /// </summary>
        /// <param name="coordinates">String representation coordinates to check.</param>
        /// <param name="expectedResult">Expected result of the checking.</param>
        [TestMethod]
        [DataRow("12,45", true)]
        [DataRow("34.45,56.9", true)]
        [DataRow("0,0", true)]
        [DataRow("8,989.211", true)]
        [DataRow("873.5567,326", true)]
        [DataRow("+4,6", true)]
        [DataRow("3,4.3,26", false)]
        [DataRow("8", false)]
        [DataRow("367.67", false)]
        [DataRow("0.233,,2.2", false)]
        [DataRow("2..2,34.4", false)]
        [DataRow("3,5u", false)]
        [DataRow("number", false)]
        [DataRow("c3,8", false)]
        [DataRow("1.4,8.99.", false)]
        [DataRow("23.5,67.8)", false)]
        [DataRow("^4,6", false)]
        [DataRow("12,12,12", false)]

        public void IsCoordinate(string coordinates, bool expectedResult)
        {
            var isCoordinate = CoordinateManager.IsCoordinates(coordinates);
            Assert.AreEqual(expectedResult, isCoordinate);
        }

        /// <summary>
        /// The test checks if a file name is correct.
        /// </summary>
        /// <param name="fileName">File name to check.</param>
        /// <param name="expectedResult">Expected result of the checking.</param>
        [TestMethod]
        [DataRow("test.txt", true)]
        [DataRow("123.12", true)]
        [DataRow("123..12", false)]
        [DataRow("12,45", false)]
        [DataRow("34.45,56.9", false)]
        [DataRow("file.", false)]
        [DataRow("12,12,12", false)]

        public void IsFileName(string fileName, bool expectedResult)
        {
            var isFileName = CoordinateManager.IsFileName(fileName);
            Assert.AreEqual(expectedResult, isFileName);
        }
    }
}
