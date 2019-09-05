using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input="")
        {
            if (string.IsNullOrEmpty(input)) return 0;
            if (input.Length > 1)
            {
                var numbers = input.Split(',').Select(int.Parse);
                return numbers.Sum();
            }

            return int.Parse(input);

        }
    }
}