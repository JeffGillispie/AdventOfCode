using System.IO;

namespace AdventOfCode
{
    /// <summary>
    /// A puzzle.
    /// </summary>
    public abstract class Puzzle
    {
        /// <summary>
        /// Gets or sets the puzzle input.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the puzzle instructions.
        /// </summary>
        public string Instructions { get; set; }
        
        /// <summary>
        /// Creates an instance of specified puzzle type with the instructions and input set.
        /// </summary>
        /// <typeparam name="T">The type of puzzle to create.</typeparam>
        /// <returns>Returns an <see cref="IPuzzle"/>.</returns>
        public static IPuzzle For<T>() where T : Puzzle, IPuzzle, new()
        {
            var puzzle = new T();
            puzzle.Instructions = puzzle.GetPuzzleInstructions();
            puzzle.Input = puzzle.GetPuzzleInput();
            return puzzle;
        }

        /// <summary>
        /// Gets the resource text by name.
        /// </summary>
        /// <param name="resourceName">The name of the resource to get.</param>
        /// <returns>Returns the resource text as a string.</returns>
        protected string GetResourceText(string resourceName)
        {
            using (var stream = this.GetType().Assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Gets the puzzle instructions from the resource matching the puzzle name.
        /// </summary>
        /// <returns>Returns the puzzle instructions as a string.</returns>
        protected string GetPuzzleInstructions()
        {
            var resourceName = $"{this.GetType().Namespace.Replace("Puzzles", "Instructions")}.{this.GetType().Name}.txt";
            return GetResourceText(resourceName);
        }

        /// <summary>
        /// Gets the puzzle input from the resource matching the puzzle name.
        /// </summary>
        /// <returns>Returns the puzzle input as a string.</returns>
        protected string GetPuzzleInput()
        {
            var resourceName = $"{this.GetType().Namespace.Replace("Puzzles", "Input")}.{this.GetType().Name}.txt";
            return GetResourceText(resourceName);
        }
    }
}
