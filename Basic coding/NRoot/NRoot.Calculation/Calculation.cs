using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRoot.Calculation
{
    public static class Calculation
    {
        /// <summary>
        /// The method calculates the N-root of the number with the required accuracy using Newton method.
        /// Or NaN if input values are not correct.
        /// </summary>
        /// <param name="number">Source number to calculate.</param>
        /// <param name="root">Root value.</param>
        /// <param name="accuracy">Accuracy of finding the number.</param>
        /// <returns>Root N-degree of the number.
        /// If accuracy is not positiv or zero,
        /// root is zero,
        /// root is even and number is negativ,
        /// number is zero and root is negativ,
        /// than returns NaN.</returns>
        public static double GetNRoot(this double number, double root, double accuracy)
        {
            if (accuracy <= 0
                || root <= 0
                || (root % 2 == 0 && number < 0))
            {
                return double.NaN;
            }

            //The first approximation of calculation. This is a formula from internet.
            var approx = 1 + ((number - 1) / root);

            while (true)
            {
                var nextApprox = approx * (1 - ((1 - number / Math.Pow(approx, root)) / root));
                var currentAccuracy = Math.Abs(approx - nextApprox);

                if (currentAccuracy < accuracy)
                {
                    approx = nextApprox;
                    break;
                }

                approx = nextApprox;
            }

            var subResult = Math.Truncate(approx / accuracy);
            return Math.Round(subResult * accuracy, GetDecimalPlace(accuracy));
        }

        /// <summary>
        /// The method returns the number of decimal after point from a given accuracy.
        /// </summary>
        /// <param name="accuracy">Source accuracy.</param>
        /// <returns>Number of decimal places after point.</returns>
        public static int GetDecimalPlace(double accuracy)
        {
            var decimalPlace = 0;
            while (accuracy < 1)
            {
                accuracy *= 10;
                decimalPlace++;
            }

            return decimalPlace;
        }
    }
}
