using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s="")
        {
            if(String.IsNullOrEmpty(s))
                return 0;
            var numbers = s.Split(",").Select(int.Parse).ToArray();
            if (numbers.Length > 1)
            {
                return numbers.First() + numbers.Last();
            }
            return int.Parse(s);
        }
    }
}