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
        /// Test ToString method of Coordinate.
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            var coordinate = new Coordinate(-43.6644, 9985.44);
            var expectedString = "X: -43,6644 Y: 9985,44";

            Assert.AreEqual(expectedString, coordinate.ToString());
        }

        /// <summary>
        /// Test Equals method of coordinate. The coordinates are equal.
        /// </summary>
        [TestMethod]
        public void EqualsTrueTest()
        {
            // The first coordinate to equal.
            var coordinate1 = new Coordinate(+76.433, -6.7544);
            // The second coordinate to equal.
            var coordinate2 = new Coordinate(+76.433, -6.7544);

            Assert.IsTrue(coordinate1.Equals(coordinate2));
        }

        /// <summary>
        /// Test Equals method of coordinate. The coordinates are not equal.
        /// </summary>
        [TestMethod]
        public void EqualsFalseTest()
        {
            // The first coordinate to equal.
            var coordinate1 = new Coordinate(+76.433, -6.7544);
            // The second coordinate to equal.
            var coordinate2 = new Coordinate(+76.433, 6.7544);

            Assert.IsFalse(coordinate1.Equals(coordinate2));
        }
    }
}
