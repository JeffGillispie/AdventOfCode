namespace AdventOfCode.Tests.Events.Year2020
{
    using System;
    using System.Collections.Generic;
    using AdventOfCode.Events.Year2020.Puzzles;

    public class TestDataForDay03 : PuzzleTestData
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new Day03 {
                    Instructions = String.Join("\n", new string[] {
                        "Part 1: Your puzzle answer was 7.",
                        "Part 2: Your puzzle answer was 336."
                    }),
                    Input = String.Join("\n", new string[] {
                        "..##.......",
                        "#...#...#..",
                        ".#....#..#.",
                        "..#.#...#.#",
                        ".#...##..#.",
                        "..#.##.....",
                        ".#.#.#....#",
                        ".#........#",
                        "#.##...#...",
                        "#...##....#",
                        ".#..#...#.#",
                    }),
                },
            };

            yield return new object[] {
                Puzzle.For<Day03>(),
            };
        }
    }
}
