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
            delimiters = GetCustomDelimiters(input, out newInput);
        }
        
        var numbers = getValidNumbers(newInput, delimiters);

        validateNegatives(numbers);
        return numbers.Sum();
    }

    private static void validateNegatives(int[] numbers)
    {
        var negatives = numbers.Where(x => x < 0).ToArray();
        if (negatives.Any())
        {
            throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
        }
    }

    private static string[] GetCustomDelimiters(string input, out string newInput)
    {
        string[] delimiters;
        var parts = input.Split('\n');
        delimiters = parts[0].Replace("//", "").Replace("[", "").Split("]");
        newInput = parts[1];
        return delimiters;
    }

    private static int[] getValidNumbers(string newInput, string[] delimiters)
    {
        return newInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).Where(x=> x <=1000).ToArray();
    }
}