using System;
using System.Linq;
using System.Reflection.Metadata;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userinput)
        {
            if (string.IsNullOrEmpty(userinput))
                return 0;

            var nums = userinput.Split(new[]{",", "\n"}, StringSplitOptions.None).Select(int.Parse).ToArray();
            return nums.Sum();
        }
    }
}