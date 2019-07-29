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
            var separator = new[] {",", "\n"};
            var validinput = userinput;
            if (userinput.StartsWith("//"))
            {
                separator = new[] {userinput.Split("\n")[0].Replace("//","").Replace("[","").Replace("]","")};
                validinput = userinput.Split("\n")[1];
            }

            var nums = validinput.Split(separator, StringSplitOptions.None).Select(int.Parse).ToArray();
            var negatives = nums.Where(x => x < 0).ToArray();
            if (negatives.Any()) throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");

            var validNums = nums.Where(x => x < 1001);
            return validNums.Sum();
        }
    }
}