namespace AdventOfCode.Events.Year2019.Puzzles
{
    using System;
    using System.Linq;

    public class Day01 : Puzzle, IPuzzle
    {
        public string GetAnswerForPart1()
        {
            return this.Input.ParseLines().ToIntegers().Sum(x => (int)(Math.Floor(x / 3.0) - 2)).ToString();            
        }

        public string GetAnswerForPart2()
        {
            var totalFuel = 0;
            Func<int, int> calculateFuel = (mass) => (int)(Math.Floor(mass / 3.0) - 2);

            foreach (var value in this.Input.ParseLines().ToIntegers())
            {
                var fuel = value;                

                while (fuel > 0)
                {
                    fuel = calculateFuel(fuel);
                    totalFuel += fuel > 0 ? fuel : 0;
                }
            }

            return totalFuel.ToString();
        }
    }
}
