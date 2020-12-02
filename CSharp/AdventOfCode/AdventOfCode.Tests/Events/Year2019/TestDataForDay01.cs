namespace AdventOfCode.Tests.Events.Year2019
{
    using System;
    using System.Collections.Generic;
    using AdventOfCode.Events.Year2019.Puzzles;    

    public class TestDataForDay01 : PuzzleTestData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new Day01 { 
                    Instructions = String.Join("\n", new string[] { 
                        "Part 1 Expected = 2",
                        "Part 2 Expected = n/a",
                    }),
                    Input = "12",
                },
            };

            yield return new object[] {
                new Day01 {
                    Instructions = String.Join("\n", new string[] {
                        "Part 1 Expected = 2",
                        "Part 2 Expected = n/a",
                    }),
                    Input = "14",
                },
            };

            yield return new object[] {
                new Day01 {
                    Instructions = String.Join("\n", new string[] {
                        "Part 1 Expected = 654",
                        "Part 2 Expected = n/a",
                    }),
                    Input = "1969",
                },
            };

            yield return new object[] {
                new Day01 {
                    Instructions = String.Join("\n", new string[] {
                        "Part 1 Expected = 33583",
                        "Part 2 Expected = n/a",
                    }),
                    Input = "100756",
                },
            };

            yield return new object[] {
                new Day01 {
                    Instructions = String.Join("\n", new string[] {
                        "Part 1 Expected = n/a",
                        "Part 2 Expected = 2",
                    }),
                    Input = "14",
                },
            };

            yield return new object[] {
                new Day01 {
                    Instructions = String.Join("\n", new string[] {
                        "Part 1 Expected = n/a",
                        "Part 2 Expected = 966",
                    }),
                    Input = "1969",
                },
            };

            yield return new object[] {
                new Day01 {
                    Instructions = String.Join("\n", new string[] {
                        "Part 1 Expected = n/a",
                        "Part 2 Expected = 50346",
                    }),
                    Input = "100756",
                },
            };

            yield return new object[] { 
                Puzzle.For<Day01>(),
            };
        }
    }
}
