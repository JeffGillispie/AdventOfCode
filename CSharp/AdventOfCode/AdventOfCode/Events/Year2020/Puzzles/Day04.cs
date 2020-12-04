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
            var passports = this.Input
                .Split(new string[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Passport(x));
            return passports.Count(x => x.HasRequiredValues).ToString();
        }

        public string GetAnswerForPart2()
        {
            var passports = this.Input
                .Split(new string[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Passport(x));
            return passports.Count(x => x.HasValidValues).ToString();
        }

        private class Passport
        {
            public Passport(string input)
            {
                var data = input
                    .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Split(new char[] { ':' }, 2))
                    .ToDictionary(x => x.First(), x => x.Last());
                this.BirthYear = data.ContainsKey("byr") ? data["byr"] : null;
                this.IssueYear = data.ContainsKey("iyr") ? data["iyr"] : null;
                this.ExpirationYear = data.ContainsKey("eyr") ? data["eyr"] : null;
                this.Height = data.ContainsKey("hgt") ? data["hgt"] : null;
                this.HairColor = data.ContainsKey("hcl") ? data["hcl"] : null;
                this.EyeColor = data.ContainsKey("ecl") ? data["ecl"] : null;
                this.PassportId = data.ContainsKey("pid") ? data["pid"] : null;
                this.CountryId = data.ContainsKey("cid") ? data["cid"] : null;
            }

            public string BirthYear { get; set; }
            public string IssueYear { get; set; }
            public string ExpirationYear { get; set; }
            public string Height { get; set; }
            public string HairColor { get; set; }
            public string EyeColor { get; set; }
            public string PassportId { get; set; }
            public string CountryId { get; set; }
            public bool HasRequiredValues
            {
                get => !String.IsNullOrEmpty(this.BirthYear) 
                    && !String.IsNullOrEmpty(this.IssueYear) 
                    && !String.IsNullOrEmpty(this.ExpirationYear)
                    && !String.IsNullOrEmpty(this.Height)
                    && !String.IsNullOrEmpty(this.HairColor)
                    && !String.IsNullOrEmpty(this.EyeColor)
                    && !String.IsNullOrEmpty(this.PassportId);
            }

            public bool HasValidValues
            {
                get
                {
                    if (this.HasRequiredValues)
                    {
                        bool hasValidBirthYear = this.IsNumberInRange(this.BirthYear, "^(\\d{4})$", 1920, 2002);
                        bool hasValidIssueYear = this.IsNumberInRange(this.IssueYear, "^(\\d{4})$", 2010, 2020);
                        bool hasValidExpirYear = this.IsNumberInRange(this.ExpirationYear, "^(\\d{4})$", 2020, 2030);
                        bool hasValidHeight = this.IsNumberInRange(this.Height, "^(\\d{3})cm$", 150, 193)
                            || this.IsNumberInRange(this.Height, "^(\\d{2})in$", 59, 75);
                        bool hasValidHairColor = Regex.IsMatch(this.HairColor, "^#[0-9a-f]{6}$");
                        bool hasValidEyeColor = Regex.IsMatch(this.EyeColor, "^(amb|blu|brn|gry|grn|hzl|oth)$");
                        bool hasValidPassportId = Regex.IsMatch(this.PassportId, "^\\d{9}$");
                        bool hasValidValues = hasValidBirthYear && hasValidIssueYear && hasValidExpirYear
                            && hasValidHeight && hasValidHairColor && hasValidEyeColor && hasValidPassportId;
                        return hasValidValues;
                    }

                    return false;
                }
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
