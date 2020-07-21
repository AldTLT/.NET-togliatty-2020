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
        /// Main method.
        /// </summary>
        static void Main()
        {

            string inputData;
            bool isInputDataCoordinates;
            bool isInputDataFileName;

            // Show intro messages.
            Console.WriteLine(Messages.Title);

            // Repeating until the correct value is entered.
            do
            {
                Console.Clear();
                // Show intro messages.
                Console.WriteLine(Messages.Title);
                Console.Write(Messages.EnterData);

                inputData = Console.ReadLine();
                isInputDataCoordinates = CoordinateManager.IsCoordinates(inputData);
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
                RedirectInputFromFile(inputData);
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

        /// <summary>
        /// The method redirect input from file and display formatted data on the console.
        /// If file not exists, display message.
        /// </summary>
        /// <param name="fileName">Name of the file from which the redirection is made.</param>
        static void RedirectInputFromFile(string fileName)
        {
            var isFileExist = File.Exists(fileName);

            if (!isFileExist)
            {
                Console.WriteLine(Messages.FileNotFound);
                return;
            }

            // Create custom reader from file.
            using (var fileReader = new StreamReader(fileName))
            {
                Console.SetIn(fileReader);
                do
                {
                    var coordinates = Console.ReadLine();

                    if (string.IsNullOrEmpty(coordinates))
                    {
                        break;
                    }

                    var parseResult = CoordinateManager.TryParse(coordinates, out Coordinate coordinate);

                    if (!parseResult)
                    {
                        Console.WriteLine(Messages.WrongCoordFormat);
                    }

                    Console.WriteLine(coordinate.ToString());
                }
                while (true);
            }
        }
    }
}
