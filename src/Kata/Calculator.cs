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

            var strings = userInput.Split(',');
            var numbers = strings.Select( stringNumber => Convert.ToInt32(stringNumber)).ToArray();
            if (numbers.Length == 1)
            {
                return numbers[0];
            }
            return numbers[0] + numbers[1];
        }
    }
}