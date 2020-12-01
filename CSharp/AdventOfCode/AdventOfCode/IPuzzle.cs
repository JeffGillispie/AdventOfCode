namespace AdventOfCode
{
    public interface IPuzzle
    {
        string Instructions { get; set; }
        string Input { get; set; }
        string GetAnswerForPart1();
        string GetAnswerForPart2();
    }
}
