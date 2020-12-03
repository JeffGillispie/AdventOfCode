namespace AdventOfCode.Events.Year2020.Puzzles
{
    using System.Linq;

    public class Day03 : Puzzle, IPuzzle
    {
        public int GetAnswerForPart1(string[] rows, int colInterval, int rowInterval)
        {
            int colIndex = 0, treeCount = 0;

            for (int rowIndex = 0; rowIndex < rows.Length; rowIndex += rowInterval)
            {
                var hasTreeAtTarget = rows[rowIndex][colIndex].Equals('#');
                colIndex = (colIndex + colInterval) % rows[rowIndex].Length;
                treeCount += hasTreeAtTarget ? 1 : 0;
            }

            return treeCount;
        }

        public string GetAnswerForPart1()
        {
            var rows = this.Input.ParseLines().ToArray();
            return this.GetAnswerForPart1(rows, 3, 1).ToString();
        }
                
        public string GetAnswerForPart2()
        {
            var slopes = new[] {
                new { X = 1, Y = 1 },
                new { X = 3, Y = 1 },
                new { X = 5, Y = 1 },
                new { X = 7, Y = 1 },
                new { X = 1, Y = 2 },
            };
            var treeCounts = slopes.Select(slope => (double)this.GetAnswerForPart1(this.Input.ParseLines().ToArray(), slope.X, slope.Y));
            var productOfTreeCounts = treeCounts.Aggregate((x, y) => x * y);
            return productOfTreeCounts.ToString();
        }
    }
}
