namespace AdventOfCode.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Test data for a puzzle.
    /// </summary>
    public abstract class PuzzleTestData : IEnumerable<object[]>
    {
        /// <summary>
        /// The collection of data to test.
        /// </summary>
        /// <returns>Returns a collection of test parameters as an object array.</returns>
        public abstract IEnumerator<object[]> GetEnumerator();

        /// <summary>
        /// The collection of data to test.
        /// </summary>
        /// <returns>Returns a collection of test parameters as an object array.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
