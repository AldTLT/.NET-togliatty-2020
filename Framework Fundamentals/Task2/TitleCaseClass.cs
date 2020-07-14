using System;
using System.Text;

namespace Task2
{
    /// <summary>
    /// The class represents methods to capitalise any string.
    /// </summary>
    public class TitleCaseClass
    {
        /// <summary>
        /// Position of a firs letter in a string; 
        /// </summary>
        const int firstLetter = 0;

        /// <summary>
        /// Overload method of TitleCase, converts a string to the title.
        /// </summary>
        /// <param name="title">String to convert.</param>
        /// <param name="exceptionWords">String of words (separated by a space)
        /// that do notneed to be translated into a header format.</param>
        /// <returns>String in the title format.</returns>
        public string TitleCase(string title, string exceptionWords)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title must not be null or empty");
            }

            var titleArray = title.Split(' ');
            var index = firstLetter;
            var result = new StringBuilder();

            while(index < titleArray.Length)
            {
                result.Append(" ");
                var titleWord = titleArray[index];

                if (index != firstLetter && IsExceptionWord(titleWord, exceptionWords))
                {
                    titleWord = titleWord.ToLower();
                }
                else
                {
                    titleWord = titleWord.ToCapitalize();
                }

                result.Append(titleWord);
                index++;
            }

            //Remove the first space
            result.Remove(firstLetter, 1);

            return result.ToString();
        }

        /// <summary>
        /// Overload method of TitleCase, converts a string to the title
        /// </summary>
        /// <param name="title">String to convert</param>
        /// <returns>String in the title format</returns>
        public string TitleCase(string title)
        {
            return TitleCase(title, null);
        }

        /// <summary>
        /// The method cheks that word is a exception word.
        /// </summary>
        /// <param name="word">A word to check</param>
        /// <param name="exceptionWords">Exception words</param>
        /// <returns>If the word is one of the exception words, returns true. Otherwise - false.</returns>
        private bool IsExceptionWord(string word, string exceptionWords)
        {
            if (string.IsNullOrEmpty(exceptionWords))
            {
                return false;
            }

            var exceptionWordsArray = exceptionWords.Split(' ');

            foreach (var exceptionWord in exceptionWordsArray)
            {
                if (word.ToLower().Equals(exceptionWord.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
