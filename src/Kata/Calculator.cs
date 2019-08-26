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
            if (numbers.Count() == 1)
            {
                return int.Parse(s);
            }

            return numbers.Sum();
        }
    }
}