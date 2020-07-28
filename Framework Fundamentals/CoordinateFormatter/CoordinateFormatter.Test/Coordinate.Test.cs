using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoordinateFormatter.Test
{
    /// <summary>
    /// The class represents tests of Coordinate methods.
    /// </summary>
    [TestClass]
    public class CoordinateTest
    {
        /// <summary>
        /// A coordinate instance to test.
        /// </summary>
        private Coordinate _coordinate;

        /// <summary>
        /// The method initializes a new coordinate.
        /// </summary>
        [TestInitialize]
        public void InitializeCoordinate()
        {
            _coordinate = new Coordinate(-43.6644, 9985.44);
        }

        /// <summary>
        /// Test ToString method of Coordinate.
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {

            var expectedString = "X: -43,6644 Y: 9985,44";

            Assert.AreEqual(expectedString, _coordinate.ToString());
        }

        /// <summary>
        /// Test Equals method of coordinate. The coordinates are equal.
        /// </summary>
        [TestMethod]
        public void EqualsTrueTest()
        {
            // Coordinate to equal.
            var coordinate = new Coordinate(-43.6644, +9985.44);

            Assert.IsTrue(coordinate.Equals(_coordinate));
        }

        /// <summary>
        /// Test Equals method of coordinate. The coordinates are not equal.
        /// </summary>
        [TestMethod]
        public void EqualsFalseTest()
        {
            // Coordinate to equal.
            var coordinate = new Coordinate(43.6644, 9985.44);

            Assert.IsFalse(coordinate.Equals(_coordinate));
        }
    }
}
