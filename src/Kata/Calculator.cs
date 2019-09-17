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
            if (input.StartsWith("//"))
            {
                var parts = newInput.Split('\n');
                delimiters = new []{ parts[0].Replace("//", "")};
                newInput = parts[1];
                
            }
            
            var numbers = newInput.Split(delimiters, StringSplitOptions.None).Select((int.Parse)).Where(x=> x<=1000).ToArray();
            
            var negatives = numbers.Where(x => x < 0).ToArray();
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
            if (numbers.Length == 1)
            {
                return int.Parse(input);    
            }
            return numbers.Sum();

        }
    }
}