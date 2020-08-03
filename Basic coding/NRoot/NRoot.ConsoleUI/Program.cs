using NRoot.Calculation;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRoot.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Messages.Title}\n");
            Console.WriteLine(Messages.Input_Value);
            var valueToCalculate = GetValueFromConsole();

            Console.WriteLine(Messages.Input_Root);
            var root = GetValueFromConsole();

            Console.WriteLine(Messages.Input_Accuracy);
            var accuracy = GetValueFromConsole();

            var nRoot = valueToCalculate.GetNRoot(root: root, accuracy: accuracy);

            if (double.IsNaN(nRoot))
            {
                Console.WriteLine(Messages.HasNotRoot);
            }
            else
            {
                Console.WriteLine($"\n{Messages.NRootResult} {nRoot}\n{nRoot}^{root}={valueToCalculate}");

                var valueByMath = Math.Pow(nRoot, root);
                Console.WriteLine($"\n{Messages.MathPowMessage} {nRoot}^{root}={valueByMath}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// The method returns double value, entered by console.
        /// </summary>
        /// <returns>Double value.</returns>
        private static double GetValueFromConsole()
        {
            double enteredValue;

            do
            {
                enteredValue = EnterValue();

                if (!double.IsNaN(enteredValue))
                {
                    break;
                }

                Console.WriteLine(Messages.TryAgain);
            }
            while (true);

            return enteredValue;
        }

        /// <summary>
        /// The method returns double value from console.
        /// </summary>
        /// <returns>Double value if entered value is correct, otherwise - double.NaN.</returns>
        private static double EnterValue()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var valueString = Console.ReadLine();
            var parseResult = double.TryParse(
                valueString,
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent | NumberStyles.AllowLeadingSign,
                currentCulture, out double value
                );

            return parseResult ? value : double.NaN;
        }
    }
}
