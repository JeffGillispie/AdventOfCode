namespace AdventOfCode.Tests.Events.Year2020
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Events.Year2020.Puzzles;

    public class TestDataForDay01 : PuzzleTestData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 
                new Day01 { 
                    Instructions = String.Join("\n", new string[] { 
                        "Part 1: Your puzzle answer was 514579.", 
                        "Part 2: Your puzzle answer was 241861950." 
                    }),
                    Input = String.Join("\n", new int[] { 
                        1721, 
                        979, 
                        366, 
                        299, 
                        675, 
                        1456,
                    }.Select(i => i.ToString())),
                },
            };

            yield return new object[] {
                Puzzle.For<Day01>(),
            };            
        }                
    }
}
