using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    /// <summary>
    /// 
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Perimeter => SideA + SideB + SideC;

        /// <summary>
        /// 
        /// </summary>
        public decimal Area => 0.5m * GetSinusA(SideA, SideB, SideC) * SideB * SideC;

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
        }


        private decimal GetSinusA(decimal sideA, decimal sideB, decimal sideC)
        {
            var cosinusA = (sideB * sideB + sideC * sideC - sideA * sideA) / 2 * sideB * sideC;
            var sinusA = Math.Sqrt((double)(1 - cosinusA * cosinusA));

            return (decimal)sinusA;
        }
    }
}
