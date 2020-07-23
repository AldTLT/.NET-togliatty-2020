using CoordinateFormatter;
using System;
using System.IO;

namespace ConsoleUI
{
    /// <summary>
    /// The class represents manager of input data and sourse file to redirect input data.
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// The method redirect input from file;
        /// </summary>
        /// <param name="fileName">Name of the file from which the redirection is made.</param>
        public static void RedirectInputFromFile(string fileName)
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

                    PrintCoordinate(coordinates);
                }
                while (true);
            }
        }

        /// <summary>
        /// The method cyclic gets coordinates from console and prints it to display.
        /// If there is no more coordinate from console (coordinate is null or empty) or there is more coordinates than numberToPrint - returns.
        /// </summary>
        /// <param name="numberToPrint">Max number of coordinates to print.</param>
        public static void PrintCoordinates(int numberToPrint)
        {
            // Initialize counter.
            var coordinateNumber = 0;

            do
            {
                var coordinate = Console.ReadLine();

                if (string.IsNullOrEmpty(coordinate) || coordinateNumber > numberToPrint)
                {
                    break;
                }

                PrintCoordinate(coordinate);
                coordinateNumber++;
            }
            while (true);
        }

        /// <summary>
        /// The method print coordinates to display.
        /// </summary>
        /// <param name="coordinates">Coordinates to print.</param>
        public static void PrintCoordinate(string coordinates)
        {
            var parseResult = CoordinateManager.TryParse(coordinates, out Coordinate coordinate);

            if (!parseResult)
            {
                Console.WriteLine($"{Messages.WrongCoordFormat} ({coordinates})");
            }
            else
            {
                Console.WriteLine(coordinate.ToString());
            }
        }

        /// <summary>
        /// The method returns size of a file in bytes.
        /// </summary>
        /// <param name="fileName">File name to get size.</param>
        /// <returns>Size of a file in bytes. If the file not exists, returns 0.</returns>
        public static long GetFileSize(string fileName)
        {
            try
            {
                using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    return file.Length;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
