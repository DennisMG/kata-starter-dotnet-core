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
                inputString = parseDelimiters(input, out delimiters);
            }
            
            var numbers = getNumbers(inputString, delimiters);
            
            validateNegatives(numbers);

            return numbers.Sum();
        }

        private static int[] getNumbers(string inputString, string[] delimiters)
        {
            return inputString.Split(delimiters, StringSplitOptions.None).Select(int.Parse).Where(x => x <= 1000).ToArray();
        }

        private static string parseDelimiters(string input, out string[] delimiters)
        {
            string inputString;
            var inputParts = input.Split("\n");

            inputString = inputParts[1];

            delimiters = inputParts[0]
                .Replace("//", "")
                .Replace("[", "")
                .Split("]");
            return inputString;
        }

        private static void validateNegatives(int[] numbers)
        {
            var negatives = numbers.Where(number => number < 0).ToArray();

            if (negatives.Any()) throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
        }
    }
}