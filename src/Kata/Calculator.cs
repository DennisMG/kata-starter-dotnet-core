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
            var sum = s.Split(new [] {",", "\n"}, StringSplitOptions.None).Select(int.Parse).ToArray().Sum();
            return sum;
        }
    }
}