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
            var separator = new [] {",", "\n"};
            var numbers = s;

            if(s.StartsWith("//"))
            {
                separator = new [] {s[2].ToString()};
                numbers = s.Split('\n')[1];

            }

            var sum = numbers.Split(separator, StringSplitOptions.None).Select(int.Parse).ToArray().Sum();

            return sum;
        }
    }
}