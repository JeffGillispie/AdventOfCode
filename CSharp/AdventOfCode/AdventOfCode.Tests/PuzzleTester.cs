namespace AdventOfCode.Tests
{
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
        [ClassData(typeof(Events.Year2020.TestDataForDay01))]
        public void Test(IPuzzle puzzle)
        {
            this.output.WriteLine(puzzle.Instructions);
            var part1Answer = puzzle.GetAnswerForPart1();
            var part2Answer = puzzle.GetAnswerForPart2();
            this.output.WriteLine("==============================");
            this.output.WriteLine($"Part 1 Answer = {part1Answer}");
            this.output.WriteLine($"Part 2 Answer = {part2Answer}");
            Assert.NotNull(part1Answer);
            Assert.NotNull(part2Answer);
        }
    }
}
