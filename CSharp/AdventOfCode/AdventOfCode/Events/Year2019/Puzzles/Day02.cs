namespace AdventOfCode.Events.Year2019.Puzzles
{
    using System;
    using System.Linq;

    public class Day02 : Puzzle, IPuzzle
    {
        public int GetAnswerForPart1(int[] input, int noun, int verb)
        {
            int[] data = new int[input.Length];
            int position = 0, opCode, firstValuePosition, secondValuePosition, outputPosition;
            input.CopyTo(data, 0);
            data[1] = noun;
            data[2] = verb;

            while (data[position] != 99)
            {
                opCode = data[position];
                firstValuePosition = data[position + 1];
                secondValuePosition = data[position + 2];
                outputPosition = data[position + 3];

                if (opCode == 1)
                    data[outputPosition] = data[firstValuePosition] + data[secondValuePosition];
                else if (opCode == 2)
                    data[outputPosition] = data[firstValuePosition] * data[secondValuePosition];
                else
                    throw new Exception("something went wrong");

                position += 4;
            }

            return data[0];
        }

        public string GetAnswerForPart1()
        {
            var inputValues = this.Input.Split(',').Where(x => !String.IsNullOrEmpty(x)).Select(x => int.Parse(x.Trim())).ToArray();
            return this.GetAnswerForPart1(this.Input.ParseDelimitedToIntegers().ToArray(), 12, 02).ToString();
        }
                
        public string GetAnswerForPart2()
        {
            var inputValues = this.Input.ParseDelimitedToIntegers().ToArray();                

            foreach (var noun in Enumerable.Range(0, 100))
            {
                foreach (var verb in Enumerable.Range(0, 100))
                {
                    int[] memory = new int[inputValues.Length];
                    inputValues.CopyTo(memory, 0);
                    

                    if (this.GetAnswerForPart1(memory, noun, verb).Equals(19690720))
                    {
                        return (100 * noun + verb).ToString();
                    }
                }
            }

            return null;
        }
    }
}
