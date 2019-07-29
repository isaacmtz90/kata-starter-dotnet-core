using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userinput)
        {
            if (userinput.Any())
            {
                return Int32.Parse(userinput);
            }
            return 0;
        }
    }
}