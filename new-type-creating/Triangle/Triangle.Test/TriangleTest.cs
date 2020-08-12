using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Test
{
    [TestClass]
    public class TriangleTest
    {
        [DataTestMethod]
        [DataRow(10.0, 10.0, 10.0)]
        [DataRow(124.356, 32.3, 98.0)]
        [DataRow(23.7, 57.1, 40.5)]
        public void CreateTriangle_Assert_Test(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle((decimal)sideA, (decimal)sideB, (decimal)sideC);

            Assert.IsInstanceOfType(triangle, typeof(Triangle));
        }

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
    }
}
