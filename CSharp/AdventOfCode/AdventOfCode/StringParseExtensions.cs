namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// Extensions to help parse data from a string.
    /// </summary>
    public static class StringParseExtensions
    {
        /// <summary>
        /// Parse delimited data in a string.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <param name="separator">The delimiter that separates the values.</param>
        /// <param name="removeEmptyValues">Indicates if empty values should be removed.</param>
        /// <param name="trimWhitespace">Indicates if whitespace should be trimmed.</param>
        /// <returns>Returns a collection of strings.</returns>
        public static IEnumerable<string> ParseDelimited(this string input, char separator = ',', bool removeEmptyValues = true, bool trimWhitespace = true)
        {
            return input.Split(separator)
                .Where(x => removeEmptyValues ? !String.IsNullOrEmpty(x) : true)
                .Select(x => trimWhitespace ? x.Trim() : x);
        }

        /// <summary>
        /// Parse delimited data in a string to integers.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <param name="separator">The delimiter separating the values in the string.</param>
        /// <returns>Returns a collection of integers.</returns>
        public static IEnumerable<int> ParseDelimitedToIntegers(this string input, char separator = ',')
        {
            return input.ParseDelimited(separator, removeEmptyValues: true, trimWhitespace: true)
                .Select(x => int.Parse(x));
        }

        /// <summary>
        /// Parse a string into lines.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <param name="removeEmptyValues">Indicates if empty values should be removed.</param>
        /// <param name="trimWhitespace">Indicates if whitespace should be trimmed.</param>
        /// <returns>Returns a collection of strings.</returns>
        public static IEnumerable<string> ParseLines(this string input, bool removeEmptyValues = true, bool trimWhitespace = true)
        {
            return input.ParseDelimited('\n', removeEmptyValues, trimWhitespace);
        }

        /// <summary>
        /// Parse a string of values separated by newlines into integers.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>Returns a collection of integers.</returns>
        public static IEnumerable<int> ParseLinesToIntegers(this string input)
        {
            return input.ParseLines(removeEmptyValues: true, trimWhitespace: true)
                .Select(x => int.Parse(x));
        }
    }
}
