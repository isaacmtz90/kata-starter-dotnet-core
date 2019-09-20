using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var separator = new[] {",", "\n"};

            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                separator = new[] {parts[0].Replace("//", "")};
                s = parts[1];
            }
            
            var numbers = s.Split(separator, StringSplitOptions.None).Select(int.Parse);
            var negatives = numbers.Where(x => x < 0).ToArray();
            
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
            if (numbers.Count() == 1) return numbers.First();

            return numbers.Sum();
        }
    }
}