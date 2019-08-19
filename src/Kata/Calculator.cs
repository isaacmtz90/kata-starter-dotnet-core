using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var separators = new[]{",", "\n"};
            var input = s;
            if (s.StartsWith("//"))
            {
                separators = new [] {s.Split("\n")[0].Replace("//","")};
                input = s.Split("\n")[1];
            }

            var numbers = input.Split(separators, StringSplitOptions.None).Select(int.Parse);

            return numbers.Sum();
        }
    }
}
