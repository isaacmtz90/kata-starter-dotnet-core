using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s =  "")
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var delimiters = new[]{",", "\n"};
            var input = s;
            if (s.StartsWith("//"))
            {
                delimiters = new[] {s.Split("\n")[0].Replace("//","")};
                input = s.Split("\n")[1];
            }

            var numbers = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ",negatives)}");
            }
            
            if (numbers.Count() == 1)
            {
                return int.Parse(s);
            }

            
            return numbers.Sum();
        }
    }
}