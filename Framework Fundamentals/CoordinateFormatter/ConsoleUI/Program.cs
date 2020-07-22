using CoordinateFormatter;
using System;

namespace ConsoleUI
{
    /// <summary>
    /// Main class Programm.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The maximum number of coordinates to print. The number is selected arbitrarily.
        /// </summary>
        const int MAX_COORD_NUMBER = 100;

        /// <summary>
        /// Main method.
        /// </summary>
        static void Main()
        {
            var isInputRedirected = Console.IsInputRedirected;
            // Count of coordinates to print. Initial value.
            var coordCount = 0;

            // Show intro messages.
            Console.Clear();
            Console.WriteLine(Messages.Title);
            Console.WriteLine(Messages.EnterData);

            do
            {
                var inputData = Console.ReadLine();

                if (inputData == null || coordCount > MAX_COORD_NUMBER)
                {
                    break;
                }

                var parseResult = CoordinateManager.TryParse(inputData, out Coordinate coordinate);
                var messageToInput = parseResult ? coordinate.ToString() : Messages.WrongCoordinate;
                coordCount++;

                Console.WriteLine(messageToInput);

                if (!isInputRedirected)
                {
                    break;
                }
            }

            while (true);

            Console.ReadLine();
        }
    }
}
