namespace AdventOfCode.Events.Year2020.Puzzles
{
    using System;    
    using System.Linq;    

    public class Day02 : Puzzle, IPuzzle
    {
        public string GetAnswerForPart1()
        {
            var inputValues = this.Input.Split('\n').Where(x => !String.IsNullOrEmpty(x)).Select(x => x.Trim());
            return inputValues.Count(entry => {
                var values = entry.Split(new char[] { '-', ' ' }).Select(c => c.TrimEnd(':')).ToArray();
                var minOccurances = int.Parse(values[0]);
                var maxOccurances = int.Parse(values[1]);
                var character = values[2].Single();
                var password = values[3];
                var occurances = password.Count(c => c.Equals(character));
                return occurances >= minOccurances && occurances <= maxOccurances;
            }).ToString();            
        }

        public string GetAnswerForPart2()
        {
            var inputValues = this.Input.Split('\n').Where(x => !String.IsNullOrEmpty(x)).Select(x => x.Trim());
            return inputValues.Count(entry => {
                var values = entry.Split(new char[] { '-', ' ' }).Select(c => c.TrimEnd(':')).ToArray();
                var position1 = int.Parse(values[0]);
                var position2 = int.Parse(values[1]);
                var character = values[2].Single();
                var password = values[3];
                return password[position1 - 1].Equals(character) ^ password[position2 - 1].Equals(character);
            }).ToString();
        }
    }
}
