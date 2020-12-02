namespace AdventOfCode.Events.Year2019.Puzzles
{
    using System;
    using System.Linq;

    public class Day01 : Puzzle, IPuzzle
    {
        public string GetAnswerForPart1()
        {
            var inputValues = this.Input.Split('\n').Where(x => !String.IsNullOrEmpty(x)).Select(x => int.Parse(x.Trim()));
            return inputValues.Sum(x => (int)(Math.Floor(x / 3.0) - 2)).ToString();            
        }

        public string GetAnswerForPart2()
        {
            var inputValues = this.Input.Split('\n').Where(x => !String.IsNullOrEmpty(x)).Select(x => int.Parse(x.Trim()));
            var totalFuel = 0;
            Func<int, int> calculateFuel = (mass) => (int)(Math.Floor(mass / 3.0) - 2);

            foreach (var value in inputValues)
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
