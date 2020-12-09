namespace AdventOfCode.Tests.Events.Year2020
{
    using System.Collections.Generic;        
    using AdventOfCode.Events.Year2020.Puzzles;

    /// <summary>
    /// Test data for <see cref="Day07"/>.
    /// </summary>
    public class TestDataForDay07 : PuzzleTestData
    {
        /// <summary>
        /// An enumerator used to iterate through the collction of test data.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the collectio of test data.</returns>
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 
                Puzzle.For<Day07>(),
            };
        }
    }
}
