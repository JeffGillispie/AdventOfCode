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
        /// An <see cref="IEnumerator"/> object that can be used to iterate through the collection of test data.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the collection of test data.</returns>
        public abstract IEnumerator<object[]> GetEnumerator();

        /// <summary>
        /// An <see cref="IEnumerator"/> object that can be used to iterate through the collection of test data.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the collection of test data.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
