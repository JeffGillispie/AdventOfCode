namespace AdventOfCode.Events.Year2020.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;    
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Day 7: Handy Haversacks
    /// </summary>
    public class Day07 : Puzzle, IPuzzle
    {
        /// <summary>
        /// How many bag colors can eventually contain at least one shiny gold bag?
        /// </summary>
        /// <returns>Returns the count of bags that contain a shiny gold bag.</returns>
        public string GetAnswerForPart1()
        {
            var rules = this.Input.ParseLines().Select(x => new BagRule(x)).ToDictionary(x => x.BagName, x => x);
            var bagsThatContainGoldBags = new HashSet<string>();

            foreach (var rule in rules.Values)
            {
                if (rule.ContainsBag("shiny gold", rules))
                {
                    bagsThatContainGoldBags.Add(rule.BagName);
                }
            }

            return bagsThatContainGoldBags.Count().ToString();
        }

        /// <summary>
        /// How many individual bags are required inside a single shiny gold bag?
        /// </summary>
        /// <returns>Returns the total count of bags held by a shiny gold bag.</returns>
        public string GetAnswerForPart2()
        {
            var rules = this.Input.ParseLines().Select(x => new BagRule(x)).ToDictionary(x => x.BagName, x => x);
            var totalBagCount = rules["shiny gold"].GetTotalBagCount(rules);
            return (totalBagCount - 1).ToString();
        }

        /// <summary>
        /// A bag rule.
        /// </summary>
        private class BagRule
        {
            /// <summary>
            /// The name of the bag.
            /// </summary>
            public string BagName;

            /// <summary>
            /// The bags contained in this bag.
            /// </summary>
            public Dictionary<string, int> BagContents;

            /// <summary>
            /// Initiates a new instance of the <see cref="BagRule"/> class.
            /// </summary>
            /// <param name="description">The rule description.</param>
            public BagRule(string description)
            {
                var descParts = description.Split(new string[] { "contain" }, StringSplitOptions.None);                
                var contentsDesc = descParts[1].Trim(new char[] { ' ', '.' });                
                this.BagName = Regex.Match(descParts[0], "\\s*([a-z\\s]+) bags").Groups[1].Value;

                if (contentsDesc.Equals("no other bags"))
                {
                    this.BagContents = new Dictionary<string, int>();
                }
                else
                {
                    this.BagContents = contentsDesc.Split(',').ToDictionary(
                            x => Regex.Match(x, "\\s*([a-z\\s]+) bags?").Groups[1].Value, 
                            x => int.Parse(Regex.Match(x, "([0-9]+)").Groups[1].Value));
                }
            }

            /// <summary>
            /// Indicates if the bag contains a specified bag.
            /// </summary>
            /// <param name="bagName">The target bag.</param>
            /// <param name="ruleMap">The map of <see cref="BagRule"/>s.</param>
            /// <returns>Returns true if this bag contains the target bag, otherwise false.</returns>
            public bool ContainsBag(string bagName, Dictionary<string, BagRule> ruleMap)
            {
                var stack = new Stack<BagRule>();
                stack.Push(this);

                while (stack.Count > 0)
                {
                    var rule = stack.Pop();
                    
                    if (rule.BagContents.ContainsKey(bagName))
                    {
                        return true;
                    }

                    rule.BagContents.Keys.ToList().ForEach(x => stack.Push(ruleMap[x]));
                }

                return false;
            }

            /// <summary>
            /// Gets the total bag count of this bag.
            /// </summary>
            /// <param name="ruleMap">The map of <see cref="BagRule"/>s.</param>
            /// <returns>Returns the total count of bags.</returns>
            public int GetTotalBagCount(Dictionary<string, BagRule> ruleMap)
            {
                int count = 1;
                
                foreach (var bagType in this.BagContents)
                {
                    var rule = ruleMap[bagType.Key];
                    count += bagType.Value * rule.GetTotalBagCount(ruleMap);
                }

                return count;
            }
        }
    }
}
