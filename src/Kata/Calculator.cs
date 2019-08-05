using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var separator = new[]{"\n",","};
            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                var customDelimiter = parts[0][2];
                separator = new [] {customDelimiter.ToString()};
                s = parts[1];
            }

            var numbers = s.Split(separator, StringSplitOptions.None).Select(int.Parse).ToArray();
            var negatives = numbers.Where(x => x < 0).ToArray();
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
            return numbers.Sum();
        }
    }
}