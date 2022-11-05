using SearchService.Api.Entities;
using SearchService.Api.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace SearchService.Api.Models
{
    public class SearchInput : ISearch
    {
        public SearchInput(string name, double lat, double lng)
        {
            Name = name;
            Position = new Location(lat, lng);
            _regex = BuildSearchRegex();
        }

        public string Name { get; set; }
        public Location Position { get; set; }
        private Regex _regex;

        public bool IsMatch(string name)
        {
            return _regex.IsMatch(name);
        }

        private Regex BuildSearchRegex()
        {
            StringBuilder searchPattern = new();

            var searchStrings = Name.Split(" ").ToList();
            searchStrings.ForEach(searchString =>
            {
                var pattern = CreateSearchPattern(searchString);
                var regexPattern = searchStrings.IndexOf(searchString) == searchStrings.Count - 1 ? pattern : $"{pattern}|";
                searchPattern.Append(regexPattern);
            });
            return new Regex(searchPattern.ToString(), RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Builds a regex pattern that matches approximatly 70% of the input string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string CreateSearchPattern(string value)
        {
            var length = value.Length;
            if (length <= 2)
            {
                return value;
            }

            var index = (int)Math.Round((length - 1) * 0.7, MidpointRounding.AwayFromZero);
            var firstPart = value.Substring(0, index);
            var secondPart = "";
            value.Substring(firstPart.Length, length - firstPart.Length).Split("").ToList().ForEach(x => secondPart += $"{x}?");

            return firstPart + secondPart;
        }

        /// <summary>
        /// Gets a score based on how many characters the matched string contains
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int GetSearchScore(string input)
        {
            var score = 0;
            _regex.Matches(input).ToList().ForEach(x => score += x.Length);
            return score;
        }
    }
}
