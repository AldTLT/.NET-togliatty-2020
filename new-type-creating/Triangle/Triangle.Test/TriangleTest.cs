using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Test
{
    /// <summary>
    /// Test of methods of Triangle class.
    /// </summary>
    [TestClass]
    public class TriangleTest
    {
        /// <summary>
        /// The test of Triangle creating.
        /// </summary>
        /// <param name="sideA">Length of side A.</param>
        /// <param name="sideB">Length of side B.</param>
        /// <param name="sideC">Length of side C.</param>
        [DataTestMethod]
        [DataRow(10.0, 10.0, 10.0)]
        [DataRow(124.356, 32.3, 98.0)]
        [DataRow(23.7, 57.1, 40.5)]
        public void CreateTriangle_Assert_Test(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle((decimal)sideA, (decimal)sideB, (decimal)sideC);

            Assert.IsInstanceOfType(triangle, typeof(Triangle));
            Assert.AreEqual((decimal)sideA, triangle.SideA);
            Assert.AreEqual((decimal)sideB, triangle.SideB);
            Assert.AreEqual((decimal)sideC, triangle.SideC);
        }

        /// <summary>
        /// The test of exception if length one of triangle side is zero or less.
        /// </summary>
        /// <param name="sideA">Length of side A.</param>
        /// <param name="sideB">Length of side B.</param>
        /// <param name="sideC">Length of side C.</param>
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(0.0, 10.0, 10.0)]
        [DataRow(124.356, 0.0, 98.0)]
        [DataRow(23.7, 57.1, 0.0)]
        [DataRow(2.0, -1.0, 2.0)]
        [DataRow(-8.9, -22.1, -15.0)]
        [DataRow(23.7, 37.1, -10.0)]
        public void SidesIsZeroOrLess_Throw_Test(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle((decimal)sideA, (decimal)sideB, (decimal)sideC);
        }

        /// <summary>
        /// The test of exception if length one of triangle side is more than two other both.
        /// </summary>
        /// <param name="sideA">Length of side A.</param>
        /// <param name="sideB">Length of side B.</param>
        /// <param name="sideC">Length of side C.</param>
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(1.0, 10.0, 15.0)]
        [DataRow(124.356, 20.0, 90.0)]
        [DataRow(10000.0, 57.1, 67.0)]
        [DataRow(2.0, 20.0, 2.0)]
        public void SidesIsTooBig_Throw_Test(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle((decimal)sideA, (decimal)sideB, (decimal)sideC);
        }

        /// <summary>
        /// The test of triangle perimeter calculate.
        /// </summary>
        /// <param name="sideA">Length of side A.</param>
        /// <param name="sideB">Length of side B.</param>
        /// <param name="sideC">Length of side C.</param>
        [DataTestMethod]
        [DataRow(10.0, 10.0, 10.0, 30.0)]
        [DataRow(124.356, 32.3, 98.0, 254.656)]
        [DataRow(23.7, 57.1, 40.5, 121.3)]
        public void Triangle_Perimeter_Test(double sideA, double sideB, double sideC, double expectedPerimeter)
        {
            var triangle = new Triangle((decimal)sideA, (decimal)sideB, (decimal)sideC);

            Assert.AreEqual((decimal)expectedPerimeter, triangle.Perimeter);
        }

        /// <summary>
        /// The test of triangle area calculate.
        /// </summary>
        /// <param name="sideA">Length of side A.</param>
        /// <param name="sideB">Length of side B.</param>
        /// <param name="sideC">Length of side C.</param>
        [DataTestMethod]
        [DataRow(10.0, 10.0, 10.0, 43.3)]
        [DataRow(34.7, 45.566, 69.22, 694.47)]
        [DataRow(23.7, 57.1, 40.5, 400.38)]
        public void Triangle_Area_Test(double sideA, double sideB, double sideC, double expectedArea)
        {
            var triangle = new Triangle((decimal)sideA, (decimal)sideB, (decimal)sideC);

            Assert.AreEqual((decimal)expectedArea, triangle.Area);
        }
    }
}
