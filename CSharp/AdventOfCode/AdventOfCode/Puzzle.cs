using System.IO;

namespace AdventOfCode
{
    public abstract class Puzzle
    {
        public string Input { get; set; }
        public string Instructions { get; set; }
        
        public static IPuzzle For<T>() where T : Puzzle, IPuzzle, new()
        {
            var puzzle = new T();
            puzzle.Instructions = puzzle.GetPuzzleInstructions();
            puzzle.Input = puzzle.GetPuzzleInput();
            return puzzle;
        }

        protected string GetResourceText(string resourceName)
        {
            using (var stream = this.GetType().Assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        protected string GetPuzzleInstructions()
        {
            var resourceName = $"{this.GetType().Namespace.Replace("Puzzles", "Instructions")}.{this.GetType().Name}.txt";
            return GetResourceText(resourceName);
        }

        protected string GetPuzzleInput()
        {
            var resourceName = $"{this.GetType().Namespace.Replace("Puzzles", "Input")}.{this.GetType().Name}.txt";
            return GetResourceText(resourceName);
        }
    }
}
