using System;
using System.Globalization;

namespace Triangle.UI
{
    /// <summary>
    /// Main class of the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method of the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine($"{Messages.Title}\n");

            Console.WriteLine(Messages.Enter_SideA);
            var sideA = GetSideOfTriangle();

            Console.WriteLine(Messages.Enter_SideB);
            var sideB = GetSideOfTriangle();

            Console.WriteLine(Messages.Enter_SideC);
            var sideC = GetSideOfTriangle();

            try
            {
                var triangle = new Triangle(sideA, sideB, sideC);
                Console.WriteLine($"\n{Messages.Output_Perimeter} {triangle.Perimeter}");
                Console.WriteLine($"{Messages.Output_Area} {triangle.Area}");
            }
            catch
            {
                Console.WriteLine(Messages.Enter_Incorrect);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// The method returns entered decimal value or zero if input incorrect.
        /// </summary>
        /// <returns>Decimal value from console or zero.</returns>
        private static decimal GetSideOfTriangle()
        {
            var culture = CultureInfo.CurrentCulture;
            var sideString = Console.ReadLine();
            var parseOk = decimal.TryParse(sideString, NumberStyles.AllowDecimalPoint ,culture, out decimal side);

            return parseOk ? side : 0;
        }
    }
}
