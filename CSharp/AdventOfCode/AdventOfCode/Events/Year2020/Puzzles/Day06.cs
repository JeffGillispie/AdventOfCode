namespace AdventOfCode.Events.Year2020.Puzzles
{
    using System.Linq;    
    using System.Text.RegularExpressions;    

    /// <summary>
    /// Day 6: Custom Customs
    /// </summary>
    public class Day06 : Puzzle, IPuzzle
    {
        /// <summary>
        /// What is the sum of the questions with affirmative responses for each group?
        /// </summary>
        /// <returns>Returns the sum of unique affirmative responses for each group.</returns>
        public string GetAnswerForPart1()
        {
            return this.Input
                .ParseGroups()
                .Sum(x => Regex.Replace(x, "\\s", string.Empty).Distinct().Count())
                .ToString();
        }

        /// <summary>
        /// What is the sum of questions where all responses are affirmative for each group.
        /// </summary>
        /// <returns>Returns the sum of questions to which all members answered affirmative for each group.</returns>
        public string GetAnswerForPart2()
        {
            return this.Input.ParseGroups().Sum(x => {
                var members = x.ParseLines();
                return members.First().Where(c => members.All(m => m.Contains(c))).Count();
            }).ToString();
        }
    }
}
