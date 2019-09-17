using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input="")
        {
            if (string.IsNullOrEmpty(input)) return 0;

            var numbers = input.Split(",").Select((int.Parse)).ToArray();
            if (numbers.Length == 1)
            {
                return int.Parse(input);    
            }
            return numbers.First() + numbers.Last();

        }
    }
}