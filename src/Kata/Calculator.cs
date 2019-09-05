using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input="")
        {
            if (string.IsNullOrEmpty(input)) return 0;
            var delimiters = new []{",", "\n"};
            var stringInput = input;
            if (input.Length > 1)
            {
                if (input.StartsWith("//"))
                {
                    var parts = input.Split("\n");
                    delimiters = parts[0].Replace("//", "").Replace("[","").Split(']');
                    stringInput = parts[1];
                }
                var numbers = stringInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
                var negative = numbers.Where(number => number < 0).ToArray();
                if(negative.Any()) throw new Exception($"negatives not allowed: {string.Join(", ", negative)}"); 
                return numbers.Where(number => number <= 1000).Sum();
            }

            return int.Parse(input);

        }
    }
}