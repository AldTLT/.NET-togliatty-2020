using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoordinateFormatter
{
    /// <summary>
    /// The class represents manager of coordinates data.
    /// </summary>
    public static class CoordinateManager
    {
        /// <summary>
        /// Converts the string representation of a coordinate to Coordinate type.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="coordinateToConvert">A string containing a coordinate to convert.</param>
        /// <param name="coordinate">When this method returns, contains Coordinate type if 
        /// the conversion succeeded, or null if the conversion failed.
        /// <returns>True if s was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string coordinateToConvert, out Coordinate coordinate)
        {
            if (string.IsNullOrEmpty(coordinateToConvert))
            {
                coordinate = null;
                return false;
            }

            var culture = CultureInfo.InvariantCulture;

            var coordinatesArray = coordinateToConvert.Split(',').Select((coordString) =>
            {
                var parseResult = double.TryParse(coordString, NumberStyles.AllowDecimalPoint, culture, out double coordDouble);
                return parseResult ? coordDouble : double.NaN;
            }).ToArray();

            // Number of coordinates - 2, - X and Y.
            const int numberOfCoordinates = 2;

            // If parse failed - coordinate sets null, and returns false.
            if (coordinatesArray.Length != numberOfCoordinates)
            {
                coordinate = null;
                return false;
            }

            var coordX = coordinatesArray.First();
            var coordY = coordinatesArray.Last();

            coordinate = new Coordinate(coordX, coordY);
            return true;
        }

        /// <summary>
        /// The method checks if a string is coordinates.
        /// </summary>
        /// <param name="coordinates">String to check.</param>
        /// <returns>True if input data is coordinates X and Y, otherwise - false.</returns>
        public static bool IsCoordinates(string coordinates)
        {
            var coordinateRegex = new Regex(@"^(\+|-)?[\d]+(\.[\d]+)?,(\+|-)?[\d]+(\.[\d]+)?$");
            return coordinateRegex.IsMatch(coordinates);
        }

        /// <summary>
        /// The method checks if a string is file name.
        /// </summary>
        /// <param name="fileName">String to check.</param>
        /// <returns>True if input data is name of file, otherwise - false.</returns>
        public static bool IsFileName(string fileName)
        {
            var fileNameRegex = new Regex(@"^\w+\.\w{1,8}$");
            return fileNameRegex.IsMatch(fileName);
        }
    }
}
