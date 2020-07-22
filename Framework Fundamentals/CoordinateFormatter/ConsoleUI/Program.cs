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
        /// The maximum file size in bytes from which data input can be redirected. The size is selected arbitrarily.
        /// </summary>
        const long MAX_FILE_SIZE = 10000;

        /// <summary>
        /// Main method.
        /// </summary>
        static void Main()
        {
            string inputData;
            bool isInputDataCoordinates;
            bool isInputDataFileName;

            // Repeating until the correct value is entered.
            do
            {
                Console.Clear();
                // Show intro messages.
                Console.WriteLine(Messages.Title);
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
                var fileSize = FileManager.GetFileSize(inputData);
                if (fileSize > MAX_FILE_SIZE)
                {
                    Console.WriteLine($"{Messages.FileTooBig} {MAX_FILE_SIZE} bytes.");
                }
                else
                {
                    FileManager.RedirectInputFromFile(inputData);
                }
            }

            // If coordinates entered - input from console.
            if (isInputDataCoordinates)
            {
                var parseResult = CoordinateManager.TryParse(inputData, out Coordinate coordinate);
                var messageToInput = parseResult ? coordinate.ToString() : Messages.WrongCoordFormat;

                Console.WriteLine(messageToInput);
            }           

            // Create standard reader from console.
            var standardInput = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(standardInput);
            Console.ReadLine();
        }
    }
}
