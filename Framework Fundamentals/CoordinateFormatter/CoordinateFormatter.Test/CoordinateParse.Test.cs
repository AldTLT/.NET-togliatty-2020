using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoordinateFormatter.Test
{
    [TestClass]
    public class CoordinateParseTest
    {
        /// <summary>
        /// The method tests parse of coordinate from correct string.
        /// </summary>
        [TestMethod]
        public void TryParseCorrectTest()
        {
            var coordinatesString = "-12.36678,4.5671";
            var coordinateExpected = new Coordinate(-12.36678, 4.5671);
            var parseResult = CoordinateManager.TryParse(coordinatesString, out Coordinate parsedCoordinate);

            Assert.AreEqual(coordinateExpected, parsedCoordinate);
            Assert.IsTrue(parseResult);
        }

        /// <summary>
        /// The method tests parse of coordinate from incorrect string.
        /// </summary>
        /// <param name="incorrectCoordinatesString">Incorrect coordinates to parse.</param>
        [TestMethod]
        [DataRow("12,12,12")]
        [DataRow("3.56,34.45.6")]
        [DataRow("Coordinate")]
        [DataRow("3.56,34.45u")]
        [DataRow("89,454.41,564")]
        [DataRow("76.45")]
        public void TryParseIncorrectTest(string incorrectCoordinatesString)
        {
            var parseResult = CoordinateManager.TryParse(incorrectCoordinatesString, out Coordinate parsedCoordinate);

            Assert.AreEqual(null, parsedCoordinate);
            Assert.IsFalse(parseResult);
        }
    }
}
