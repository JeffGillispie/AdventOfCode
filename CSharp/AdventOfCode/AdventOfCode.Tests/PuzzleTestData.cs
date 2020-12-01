namespace AdventOfCode.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class PuzzleTestData : IEnumerable<object[]>
    {
        public abstract IEnumerator<object[]> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
