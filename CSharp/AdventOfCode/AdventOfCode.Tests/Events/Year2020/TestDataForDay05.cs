namespace AdventOfCode.Tests.Events.Year2020
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;    
    using AdventOfCode.Events.Year2020.Puzzles;

    public class TestDataForDay05 : PuzzleTestData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 
                new Day05 { 
                    Instructions = @"
                        Your puzzle answer was 567.
                        Your puzzle answer was n/a.",
                    Input = "BFFFBBFRRR",
                },
            };

            yield return new object[] { 
                Puzzle.For<Day05>(),
            };
        }
    }
}
