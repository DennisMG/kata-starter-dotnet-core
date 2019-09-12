using System.Linq;

public class Calculator
{
    public int Add(string input = "")
    {
        if (string.IsNullOrEmpty(input)) return 0;

        var numbers = input.Split(",").Select(int.Parse).ToArray();
        if (numbers.Count() == 1) return numbers.First();
        return numbers.First() + numbers.Last();
    }
}