namespace AdventOfCode.Tests.Events.Year2019
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Events.Year2019.Puzzles;

    public class TestDataForDay02 : PuzzleTestData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 
                Puzzle.For<Day02>(),
            };
        }
    }
}
