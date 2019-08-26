using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s =  "")
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var numbers = s.Split(new[]{",", "\n"}, StringSplitOptions.None).Select(int.Parse);
            if (numbers.Count() == 1)
            {
                return int.Parse(s);
            }

            return numbers.Sum();
        }
    }
}