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
            var inputString = input;
            if (input.StartsWith("//"))
            {
                var inputParts = input.Split("\n");
                
                inputString = inputParts[1];
                
                delimiters = new[] {inputParts[0].Replace("//", "")};
            }
            
            var numbers = inputString.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
            if (numbers.Count() > 1) return numbers.Sum();
            return numbers.First();
        }
    }
}