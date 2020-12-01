using System.IO;

namespace AdventOfCode
{
    public abstract class Puzzle : IPuzzle
    {
        public string Input { get; set; }
        public string Instructions { get; set; }
        public abstract string GetAnswerForPart1();
        public abstract string GetAnswerForPart2();
        
        public static IPuzzle For<T>() where T : Puzzle, new()
        {
            var puzzle = new T();
            puzzle.Instructions = GetPuzzleInstructions(typeof(T));
            puzzle.Input = GetPuzzleInput(typeof(T));
            return puzzle;
        }

        protected static string GetResourceText(string resourceName)
        {
            using (var stream = typeof(Puzzle).Assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        protected static string GetPuzzleInstructions(System.Type type)
        {
            var resourceName = $"{type.Namespace.Replace("Puzzles", "Instructions")}.{type.Name}.txt";
            return GetResourceText(resourceName);
        }

        protected static string GetPuzzleInput(System.Type type)
        {
            var resourceName = $"{type.Namespace.Replace("Puzzles", "Input")}.{type.Name}.txt";
            return GetResourceText(resourceName);
        }
    }
}
