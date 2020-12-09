namespace AdventOfCode.Tests
{
    using System.Text.RegularExpressions;
    using AdventOfCode;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// The puzzle tester.
    /// </summary>
    public class PuzzleTester
    {
        /// <summary>
        /// The test output helper.
        /// </summary>
        protected readonly ITestOutputHelper output;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleTester"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public PuzzleTester(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Tests that the puzzle answers in the instructions matches the answers produced by the puzzle methods.
        /// Skips the answer validation if the instructions specify an answer of 'n/a'.
        /// </summary>
        /// <param name="puzzle">The puzzle to test.</param>
        [Theory]
        [ClassData(typeof(Events.Year2019.TestDataForDay01))]
        [ClassData(typeof(Events.Year2019.TestDataForDay02))]
        [ClassData(typeof(Events.Year2020.TestDataForDay01))]
        [ClassData(typeof(Events.Year2020.TestDataForDay02))]
        [ClassData(typeof(Events.Year2020.TestDataForDay03))]
        [ClassData(typeof(Events.Year2020.TestDataForDay04))]
        [ClassData(typeof(Events.Year2020.TestDataForDay05))]
        [ClassData(typeof(Events.Year2020.TestDataForDay06))]
        [ClassData(typeof(Events.Year2020.TestDataForDay07))]
        public void TestPuzzle(IPuzzle puzzle)
        {
            var matches = Regex.Matches(puzzle.Instructions, "Your puzzle answer was (.+)\\.\\s?");
            var expectedPart1 = matches[0].Groups[1].Value;
            var expectedPart2 = matches[1].Groups[1].Value;
            var part1Answer = puzzle.GetAnswerForPart1();
            var part2Answer = puzzle.GetAnswerForPart2();
            this.output.WriteLine($"Test for {puzzle.GetType().Namespace}.{puzzle.GetType().Name}");
            this.output.WriteLine("==============================");
            this.output.WriteLine($"Part 1: Expected '{expectedPart1}', Actual '{part1Answer}'");
            this.output.WriteLine($"Part 2: Expected '{expectedPart2}', Actual '{part2Answer}'");
            Assert.NotNull(part1Answer);
            Assert.NotNull(part2Answer);

            if (!expectedPart1.Equals("n/a"))
            {
                Assert.Equal(expectedPart1, part1Answer);
            }

            if (!expectedPart2.Equals("n/a"))
            {
                Assert.Equal(expectedPart2, part2Answer);
            }
        }
    }
}
