namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class StringParseExtensions
    {
        public static IEnumerable<string> ParseDelimited(this string input, char separator = ',', bool removeEmptyValues = true, bool trimWhitespace = true)
        {
            return input.Split(separator)
                .Where(x => removeEmptyValues ? !String.IsNullOrEmpty(x) : true)
                .Select(x => trimWhitespace ? x.Trim() : x);
        }

        public static IEnumerable<int> ParseDelimitedToIntegers(this string input, char separator = ',', bool removeEmptyValues = true, bool trimWhitespace = true)
        {
            return input.ParseDelimited(separator, removeEmptyValues, trimWhitespace)
                .Select(x => int.Parse(x));
        }

        public static IEnumerable<string> ParseLines(this string input, bool removeEmptyValues = true, bool trimWhitespace = true)
        {
            return input.ParseDelimited('\n', removeEmptyValues, trimWhitespace);
        }

        public static IEnumerable<int> ParseLinesToIntegers(this string input)
        {
            return input.ParseLines(removeEmptyValues: true, trimWhitespace: true)
                .Select(x => int.Parse(x));
        }
    }
}
