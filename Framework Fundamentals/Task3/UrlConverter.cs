using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task3
{
    /// <summary>
    /// The class represents a url manager.
    /// </summary>
    public class UrlConverter
    {
        /// <summary>
        /// The method changes the key=value parameters of url or adds a new key=value parameter
        /// to the url if the new parameter does not already exist.
        /// </summary>
        /// <param name="url">Url to manipulate.</param>
        /// <param name="keyValueParameter">Key=value parameter to changes or adds.</param>
        /// <returns>New url with changed or added parameters.</returns>
        public string AddUrlParameter(string url, string keyValueParameter)
        {
            CheckParameter(url, keyValueParameter);

            string newUrl;
            var keyValue = keyValueParameter.Split('=');
            var parameterContains = new Regex($@"\W{Regex.Escape(keyValue[0])}=\w+", RegexOptions.IgnoreCase);
            var result = parameterContains.IsMatch(url);

            if (result)
            {
                newUrl = ChangeParameter(url, keyValueParameter);
            }
            else
            {
                newUrl = AddParameter(url, keyValueParameter);
            }

            return newUrl;
        }

        /// <summary>
        /// The method validates of url.
        /// </summary>
        /// <param name="url">Url to check.</param>
        /// <returns>Result of validation.</returns>
        private bool IsUrl(string url)
        {
            var urlRegex = new Regex(@"^(?:http(s)?:\/\/)?\w+(?:\.)+[\S+]+$", RegexOptions.IgnoreCase);
            var result = urlRegex.IsMatch(url);
            return result;
        }

        /// <summary>
        /// The method validates of key=value parameter. 
        /// </summary>
        /// <param name="keyValueParameter">Key=value parameter to check.</param>
        /// <returns>Result of validation.</returns>
        private bool IsKeyValue(string keyValueParameter)
        {
            var keyValueRegex = new Regex(@"^\w+=\w+$", RegexOptions.IgnoreCase);
            var result = keyValueRegex.IsMatch(keyValueParameter);
            return result;
        }

        /// <summary>
        /// The method attaches the keyValue to the url.
        /// </summary>
        /// <param name="url">Source url</param>
        /// <param name="keyValueParameter">Key and value to attach.</param>
        /// <returns>Url with new key and value.</returns>
        private string AddParameter(string url, string keyValueParameter)
        {
            var regex = new Regex(@"\W\w+=\w+$", RegexOptions.IgnoreCase);
            var containKey = regex.IsMatch(url);
            var concatSymbol = containKey ? "&" : "?";
            var newUrl = url + concatSymbol + keyValueParameter;

            return newUrl;
        }

        /// <summary>
        /// The method replaces the value by key with another value in url.
        /// </summary>
        /// <param name="url">Source url.</param>
        /// <param name="keyValueParameter">Key and value to replace.</param>
        /// <returns>Url with replaced value.</returns>
        private string ChangeParameter(string url, string keyValueParameter)
        {
            var keyValue = keyValueParameter.Split('=');
            var concat = new Regex($@"\?{keyValue[0]}=", RegexOptions.IgnoreCase);
            var concatSymbol = concat.IsMatch(url) ? "?" : "&";
            var newUrl = Regex.Replace(url, $@"\W{Regex.Escape(keyValue[0])}=\w+", concatSymbol + keyValueParameter);
            
            return newUrl;
        }

        /// <summary>
        /// The method checks the url and keyValueParameter for exceptions.
        /// </summary>
        /// <param name="url">url to check</param>
        /// <param name="keyValueParameter">keyValueParameter to check.</param>
        private void CheckParameter(string url, string keyValueParameter)
        {
            if (string.IsNullOrEmpty(url) || !IsUrl(url))
            {
                throw new ArgumentException("url is not correct!");
            }

            if (string.IsNullOrEmpty(keyValueParameter) || !IsKeyValue(keyValueParameter))
            {
                throw new ArgumentException("keyValueParameter is not correct!");
            }
        }
    }
}
