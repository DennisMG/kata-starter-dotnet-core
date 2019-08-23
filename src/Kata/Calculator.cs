namespace Kata
{
    public class Calculator
    {
        public int Add(string number = "")
        {
            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            var splittedNumbers = number.Split(',');
            if (splittedNumbers.Length <= 1) return int.Parse(number);
            var first = int.Parse(splittedNumbers[0]);
            var second = int.Parse(splittedNumbers[1]);
            return first + second;
        }
    }
}