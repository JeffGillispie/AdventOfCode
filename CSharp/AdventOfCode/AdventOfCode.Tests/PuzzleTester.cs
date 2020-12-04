namespace AdventOfCode.Tests
{
    using System.Text.RegularExpressions;
    using AdventOfCode;
    using Xunit;
    using Xunit.Abstractions;

    public class PuzzleTester
    {
        protected readonly ITestOutputHelper output;
        
        public PuzzleTester(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [ClassData(typeof(Events.Year2019.TestDataForDay01))]
        [ClassData(typeof(Events.Year2019.TestDataForDay02))]
        [ClassData(typeof(Events.Year2020.TestDataForDay01))]
        [ClassData(typeof(Events.Year2020.TestDataForDay02))]
        [ClassData(typeof(Events.Year2020.TestDataForDay03))]
        [ClassData(typeof(Events.Year2020.TestDataForDay04))]
        public void Test(IPuzzle puzzle)
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
