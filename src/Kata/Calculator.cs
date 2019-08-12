using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            var input = s;
            if(string.IsNullOrEmpty(input))
                return 0;
            
            var separator = new [] {",","\n"};
            if (input.StartsWith("//"))
            {
                var parts = input.Split("\n");
                input = parts[1];
                separator = new[] {parts[0].Replace("//", "")};
            }

            var numbers = input.Split(separator, StringSplitOptions.None).Select((x) => int.Parse(x)).ToArray();
            return numbers.Sum();
        }
    }
}