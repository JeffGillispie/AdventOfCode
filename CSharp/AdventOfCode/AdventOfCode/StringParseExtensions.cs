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
        /// <param name="separator">The delimiter that separate the values.</param>
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
        /// Parse groups of data in a string separated by a blank line.
        /// </summary>
        /// <param name="input">The string to parse.</param>        
        /// <param name="splitOptions">The string split options to use.</param>
        /// <returns>Returns a collection of strings.</returns>
        public static IEnumerable<string> ParseGroups(this string input, StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries)
        {
            return input.Split(new string[] { "\n\n", "\r\n\r\n" }, splitOptions);
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
        /// Convert a collection of strings to integers.
        /// </summary>
        /// <param name="values">The values to convert.</param>
        /// <returns>Returns a collection of integers.</returns>
        public static IEnumerable<int> ToIntegers(this IEnumerable<string> values)
        {
            return values.Select(x => int.Parse(x));
        }
    }
}
