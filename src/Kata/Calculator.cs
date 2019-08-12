using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if(string.IsNullOrEmpty(s))
                return 0;
            var numbers = s.Split(new [] {",","\n"}, StringSplitOptions.None).Select((x) => int.Parse(x)).ToArray();
            return numbers.Sum();
        }
    }
}