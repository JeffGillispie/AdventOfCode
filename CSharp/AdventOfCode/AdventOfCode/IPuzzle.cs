namespace AdventOfCode
{
    /// <summary>
    /// The puzzle interface.
    /// </summary>
    public interface IPuzzle
    {
        /// <summary>
        /// Gets or sets the puzzle instructions.
        /// </summary>
        string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the puzzle input.
        /// </summary>
        string Input { get; set; }

        /// <summary>
        /// Gets the puzzle answer for part 1.
        /// </summary>
        /// <returns>Returns the answer as a string.</returns>
        string GetAnswerForPart1();

        /// <summary>
        /// Gets the puzzle answer for part 2.
        /// </summary>
        /// <returns>Returns the answer as a string.</returns>
        string GetAnswerForPart2();
    }
}
