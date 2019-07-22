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

            var strings = userInput.Split(new [] {',','\n'});
            var numbers = strings.Select( stringNumber => Convert.ToInt32(stringNumber)).ToArray();
            return numbers.Sum();
        }
    }
}