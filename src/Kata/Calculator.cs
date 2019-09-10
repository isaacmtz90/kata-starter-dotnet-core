using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var delimiters = new[] {",", "\n"};
            var inputString = s;
            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                delimiters = new[] {parts[0].Replace("//", "")};
                inputString = parts[1];
            }

            var numbers = inputString.Split(delimiters, StringSplitOptions.None).Select(int.Parse);

            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: -3");
            }
            return numbers.Sum();
        }
    }
}