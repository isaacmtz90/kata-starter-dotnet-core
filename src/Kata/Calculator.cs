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
            if (numbers.Count() == 1)
                return numbers.First();

            return numbers.Sum();
        }
    }
}