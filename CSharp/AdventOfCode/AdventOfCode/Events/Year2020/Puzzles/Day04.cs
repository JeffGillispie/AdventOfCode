namespace AdventOfCode.Events.Year2020.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day04 : Puzzle, IPuzzle
    {
        public string GetAnswerForPart1()
        {
            var passports = this.Input.ParseGroups().Select(x => new Passport(x));
            return passports.Count(x => x.HasRequiredFields).ToString();
        }

        public string GetAnswerForPart2()
        {
            var passports = this.Input.ParseGroups().Select(x => new Passport(x));
            return passports.Count(x => x.HasValidValues).ToString();
        }

        private class Passport
        {
            public readonly Dictionary<string, string> FieldMap;
            public Passport(string input)
            {
                this.FieldMap = input
                    .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Split(new char[] { ':' }, 2))
                    .ToDictionary(x => x.First(), x => x.Last());                
            }

            public bool HasRequiredFields
            {
                get => new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" }.All(key => this.FieldMap.ContainsKey(key));                    
            }

            public bool HasValidValues
            {
                get => this.HasRequiredFields
                    && this.IsNumberInRange(this.FieldMap["byr"], "^(\\d{4})$", 1920, 2002)
                    && this.IsNumberInRange(this.FieldMap["iyr"], "^(\\d{4})$", 2010, 2020)
                    && this.IsNumberInRange(this.FieldMap["eyr"], "^(\\d{4})$", 2020, 2030)
                    && (this.IsNumberInRange(this.FieldMap["hgt"], "^(\\d{3})cm$", 150, 193) || this.IsNumberInRange(this.FieldMap["hgt"], "^(\\d{2})in$", 59, 75))
                    && Regex.IsMatch(this.FieldMap["hcl"], "^#[0-9a-f]{6}$")
                    && Regex.IsMatch(this.FieldMap["ecl"], "^(amb|blu|brn|gry|grn|hzl|oth)$")
                    && Regex.IsMatch(this.FieldMap["pid"], "^\\d{9}$");
            }

            public bool IsNumberInRange(string val, string capturePattern, int min, int max)
            {
                var match = Regex.Match(val, capturePattern);

                if (match.Success)
                {
                    var num = int.Parse(match.Groups[1].Value);
                    return min <= num && num <= max;
                }

                return false;
            }
        }
    }
}
