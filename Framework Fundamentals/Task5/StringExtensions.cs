using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// The class represents string extension contains method ReverseWords.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The method reverses words in a string
        /// </summary>
        /// <param name="sourceString">String to reverses words</param>
        /// <returns>String with reverses words</returns>
        public static string ReverseWords(this string sourceString)
        {
            if (string .IsNullOrEmpty(sourceString))
            {
                return sourceString;
            }

            var reverseWordsEnumerable = sourceString.Split(' ').Reverse();
            var reverseString = new StringBuilder();

            foreach (var word in reverseWordsEnumerable)
            {
                reverseString.Append($"{word} ");
            }

            if (reverseString.Length > 0)
            {
                //Remote the last space in the end of the string
                reverseString.Remove(reverseString.Length - 1, 1);
            }

            return reverseString.ToString();
        }
    }
}
