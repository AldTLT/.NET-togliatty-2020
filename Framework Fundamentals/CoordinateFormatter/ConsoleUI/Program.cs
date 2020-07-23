using CoordinateFormatter;
using System;
using System.IO;

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
        /// The maximum file size in bytes from which data input can be redirected. The size is selected arbitrarily.
        /// </summary>
        const long MAX_FILE_SIZE = 10000;

        /// <summary>
        /// Main method.
        /// </summary>
        static void Main()
        {
            string inputData = string.Empty;
            bool isInputDataCoordinates;
            bool isInputDataFileName;

            // Repeating until the correct value is entered.
            do
            {
                Console.Clear();
                // Show intro messages.
                Console.WriteLine(Messages.Title);

                if (Console.IsInputRedirected)
                {
                    isInputDataCoordinates = true;
                    isInputDataFileName = false;
                    break;
                }

                Console.Write(Messages.EnterData);

                inputData = Console.ReadLine();
                // Check if a input data is coordinate.

                isInputDataCoordinates = CoordinateManager.IsCoordinates(inputData);
                // Check if a input data is file name.
                isInputDataFileName = CoordinateManager.IsFileName(inputData);

                if (isInputDataCoordinates || isInputDataFileName)
                {
                    break;
                }

                Console.WriteLine(Messages.IncorrectlyInsert);
                Console.ReadKey();
            }
            while (true);

            // If file name entered - redirect input from file.
            if (isInputDataFileName)
            {
                PrintByFileName(inputData);
            }

            // If coordinates entered - input from console.
            if (isInputDataCoordinates)
            {
                PrintByCoordinates(inputData);
            }

            // Create standard reader from console.
            var standardInput = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(standardInput);
            Console.ReadLine();
        }

        /// <summary>
        /// The method prints data from file to console.
        /// </summary>
        /// <param name="fileName">Name of the file from which gets data to print.</param>
        private static void PrintByFileName(string fileName)
        {
            var fileSize = FileManager.GetFileSize(fileName);
            if (fileSize > MAX_FILE_SIZE)
            {
                Console.WriteLine($"{Messages.FileTooBig} {MAX_FILE_SIZE} bytes.");
            }
            else
            {
                FileManager.RedirectInputFromFile(fileName);
            }
        }

        /// <summary>
        /// The method prints coordinates to console.
        /// </summary>
        /// <param name="coordinates">Coordinate to print.</param>
        private static void PrintByCoordinates(string coordinates)
        {
            if (Console.IsInputRedirected)
            {
                FileManager.PrintCoordinates(MAX_COORD_NUMBER);
            }
            else
            {
                FileManager.PrintCoordinate(coordinates);
            }
        }
    }
}
