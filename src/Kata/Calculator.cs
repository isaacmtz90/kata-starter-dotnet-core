using System;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s="")
        {
            if (string.IsNullOrEmpty(s))
            {
            return 0;
               
            }
            return Int32.Parse(s);
            
        }
    }
}