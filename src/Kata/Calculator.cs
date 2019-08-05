using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var numbers = s.Split(",").Select(int.Parse).ToArray();
            if (numbers.Length == 1) return numbers.First();
            return numbers.First()+numbers.Last();
        }
    }
}