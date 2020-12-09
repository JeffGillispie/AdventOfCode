namespace AdventOfCode.Events.Year2020.Puzzles
{
    using System;    
    using System.Linq;    

    public class Day05 : Puzzle, IPuzzle
    {
        public string GetAnswerForPart1()
        {
            return this.Input.ParseLines().Max(x => this.GetSeatId(x)).ToString();            
        }

        public string GetAnswerForPart2()
        {
            var seatIds = this.Input.ParseLines().Select(x => this.GetSeatId(x)).OrderBy(x => x).ToList();
            var missingSeatId = seatIds.FirstOrDefault(x => { 
                return !x.Equals(seatIds.First()) 
                    && !x.Equals(seatIds.Last())
                    && (x + 2).Equals(seatIds[seatIds.IndexOf(x) + 1]); 
            }) + 1;
            return missingSeatId.ToString();
        }

        private int GetNumberFromBinaryString(string val)
        {
            var binary = val.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1');
            var number = Convert.ToInt32(binary, 2);
            return number;
        }

        private int GetSeatId(string val)
        {
            var row = this.GetNumberFromBinaryString(val.Substring(0, 7));
            var col = this.GetNumberFromBinaryString(val.Substring(7));
            return row * 8 + col;
        }
    }
}
