using System.Text;

namespace Task2
{
    /// <summary>
    /// The class represents extension of the string class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The method returns a copy of this string converted to capitalize.
        /// </summary>
        /// <param name="str">A string to capitalize.</param>
        /// <returns>A string in capitalize.</returns>
        public static string ToCapitalize(this string str)
        {
            var result = new StringBuilder();
            var first = true;

            foreach (var symbol in str)
            {
                if (first)
                {
                    result.Append(char.ToUpper(symbol));
                    first = false;
                    continue;
                }

                result.Append(char.ToLower(symbol));
            }

            return result.ToString();
        }
    }
}
