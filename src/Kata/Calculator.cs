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

            var nums = userinput.Split(",").Select(int.Parse).ToArray();
            if (nums.Length == 1) return nums[0];
            
            return nums[0]+nums[1];
        }
    }
}