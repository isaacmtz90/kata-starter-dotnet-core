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
            var inputString = s;

            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                separator =
                    parts[0].Replace("//", "")
                        .Replace("[", "")
                        .Split("]");
                
                inputString = parts[1];
            }

            var numbers = inputString.Split(separator, StringSplitOptions.None).Select(int.Parse).Where(x=> x<=1000).ToArray();
            var negatives = numbers.Where(x => x < 0).ToArray();
            
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            return numbers.Sum();
        }
    }
}