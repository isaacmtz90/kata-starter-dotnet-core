using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput)
        {
            if(string.IsNullOrEmpty(userInput))
                return 0;
            
            var input = userInput;
            var delimiters = new [] {',','\n'};

            if (input.StartsWith("//"))
            {
                delimiters = new[] {input[2]};
                input = userInput.Substring(4);
            }
            
            var strings = input.Split(delimiters);
            var numbers = strings.Select( stringNumber => Convert.ToInt32(stringNumber)).ToArray();
            return numbers.Sum();
        }
    }
}