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
        var numbers = newInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();
        if (numbers.Count() == 1) return numbers.First();
        return numbers.Sum();
    }
}