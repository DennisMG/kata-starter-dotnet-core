using System;
using System.Linq;

public class Calculator
{
    public int Add(string input = "")
    {
        if (string.IsNullOrEmpty(input)) return 0;

        var delimiters = new [] {",","\n"};
        var newInput = input;
        if (input.StartsWith("//"))
        {
            var parts = input.Split('\n');
            delimiters = new[] { parts[0].Replace("//", "")};
            newInput = parts[1];
        }
        
        var numbers = newInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).Where(x=> x <=1000).ToArray();

        var negatives = numbers.Where(x => x < 0).ToArray();
        if (negatives.Any())
        {
            throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
        }
        if (numbers.Count() == 1) return numbers.First();
        return numbers.Sum();
    }
}