using System;

namespace Triangle
{
    /// <summary>
    /// The class represents triangle description.
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// Perimeter of triangle.
        /// P = SideA + SideB + SideC
        /// </summary>
        public decimal Perimeter => SideA + SideB + SideC;

        /// <summary>
        /// Area of triangle.
        /// A = Sqrt(1 - ((SideB^2 + SideC^2 - SideA^2) / (2 * SideB * SideC))^2) * SideB * SideC * 0.5
        /// </summary>
        public decimal Area => GetArea(SideA, SideB, SideC);

        /// <summary>
        /// Side A of the triangle 
        /// </summary>
        public decimal SideA { get; }

        /// <summary>
        /// Side B of the triangle 
        /// </summary>
        public decimal SideB { get; }

        /// <summary>
        /// Side C of the triangle 
        /// </summary>
        public decimal SideC { get; }

        /// <summary>
        /// Constructor of a triangle instance.
        /// </summary>
        /// <param name="sideA">Side A of a triangle.</param>
        /// <param name="sideB">Side B of a triangle.</param>
        /// <param name="sideC">Side C of a triangle.</param>
        public Triangle(decimal sideA, decimal sideB, decimal sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException(Messages.TriangleSideIsZero);
            }

            if (sideA + sideB <= sideC || sideB + sideC <= sideA || sideA + sideC <= sideB)
            {
                throw new ArgumentException(Messages.TriangleSideIsBig);
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// The method returns area of triangle. The value is rounded to two decimal places.
        /// </summary>
        /// <param name="sideA">Side A of a triangle.</param>
        /// <param name="sideB">Side B of a triangle.</param>
        /// <param name="sideC">Side C of a triangle.</param>
        /// <returns>Area of a triangle.</returns>
        private decimal GetArea(decimal sideA, decimal sideB, decimal sideC)
        {
            var cosinusA = (sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideB * sideC);
            var sinusA = Math.Sqrt((double)(1 - cosinusA * cosinusA));
            var area = 0.5m * (decimal)sinusA * SideB * SideC;

            return Math.Round(area, 2);
        }
    }
}
