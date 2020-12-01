namespace AdventOfCode.Events.Year2020.Puzzles
{
    using System;
    using System.Linq;

    public class Day01 : Puzzle, IPuzzle
    {
        public override string GetAnswerForPart1()
        {
            var inputValues = this.Input.Split('\n').Where(x => !String.IsNullOrEmpty(x)).Select(x => int.Parse(x.Trim())).ToArray();
            
            for (int indexNum1 = 0; indexNum1 < inputValues.Length; indexNum1++)
            {
                for (int indexNum2 = 0; indexNum2 < inputValues.Length; indexNum2++)
                {
                    if (indexNum2.Equals(indexNum1))
                    {
                        continue;
                    }

                    int num1 = inputValues[indexNum1];
                    int num2 = inputValues[indexNum2];

                    if (num1 + num2 == 2020)
                    {
                        return (num1 * num2).ToString();
                    }
                }
            }

            return null;
        }

        public override string GetAnswerForPart2()
        {
            var inputValues = this.Input.Split('\n').Where(x => !String.IsNullOrEmpty(x)).Select(x => int.Parse(x.Trim())).ToArray();

            for (int indexNum1 = 0; indexNum1 < inputValues.Length; indexNum1++)
            {
                for (int indexNum2 = 0; indexNum2 < inputValues.Length; indexNum2++)
                {
                    for (int indexNum3 = 0; indexNum3 < inputValues.Length; indexNum3++)
                    {
                        if (indexNum2.Equals(indexNum1) || indexNum3.Equals(indexNum2) || indexNum3.Equals(indexNum1))
                        {
                            continue;
                        }

                        int num1 = inputValues[indexNum1];
                        int num2 = inputValues[indexNum2];
                        int num3 = inputValues[indexNum3];

                        if (num1 + num2 + num3 == 2020)
                        {
                            return (num1 * num2 * num3).ToString();
                        }
                    }
                }
            }

            return null;
        }
    }
}
