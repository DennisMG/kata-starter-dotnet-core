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
                    delimiters = new[] {parts[0].Replace("//", "")};
                    stringInput = parts[1];
                }
                var numbers = stringInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
                return numbers.Sum();
            }

            return int.Parse(input);

        }
    }
}