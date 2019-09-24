using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input = "")
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = new[] {",", "\n"};
            var numbers = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
            if (numbers.Count() > 1) return numbers.Sum();
            return numbers.First();
        }
    }
}