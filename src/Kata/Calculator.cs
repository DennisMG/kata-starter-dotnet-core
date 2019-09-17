using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input="")
        {
            if (string.IsNullOrEmpty(input)) return 0;

            var delimiters = new [] {",","\n"};
            var newInput = input;
            newInput = extractcustomDelimiters(input, newInput, ref delimiters);
            
            var numbers = newInput.Split(delimiters, StringSplitOptions.None).Select((int.Parse)).Where(x=> x<=1000).ToArray();
            
            var negatives = numbers.Where(x => x < 0).ToArray();
            validateNegatives(negatives);
            
            return numbers.Sum();

        }

        private static string extractcustomDelimiters(string input, string newInput, ref string[] delimiters)
        {
            if (input.StartsWith("//"))
            {
                var parts = newInput.Split('\n');
                delimiters = parts[0].Replace("//", "").Replace("[", "").Split("]").ToArray();
                newInput = parts[1];
            }

            return newInput;
        }

        private static void validateNegatives(int[] negatives)
        {
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
        }
    }
}