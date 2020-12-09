namespace AdventOfCode.Tests.Events.Year2020
{
    using System.Collections.Generic;
    using AdventOfCode.Events.Year2020.Puzzles;

    public class TestDataForDay06 : PuzzleTestData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 
                Puzzle.For<Day06>(),
            };
        }
    }
}
