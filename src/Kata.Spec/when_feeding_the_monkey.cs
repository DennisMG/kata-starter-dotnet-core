using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;
        
        Establish context = () => 
            _systemUnderTest = new Monkey();

        Because of = () => 
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }

    public class when_input_is_empty
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_just_one_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("4"); };

        It should_return_that_number = () => { _result.Should().Be(4); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_two_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2"); };

        It should_calculate_the_sum = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_an_unknown_amount_of_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,7"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(10); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_multiple_num_with_new_line
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1\n2,3"); };

        It should_return_the_sum = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_a_custom_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };

        It should_split_by_that_delimiter_and_return_the_sum = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_contains_negative_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        private Because of = () =>
        {
            _result = Catch.Exception(() => { _systemUnderTest.Add("1,2,-3,4"); });
        };
        
    

        It should_throw_exception = () => { _result.Message.Should().Be("negatives not allowed: -3"); };
        private static Calculator _systemUnderTest;
        private static Exception _result;
    }

    public class when_input_contains_multiple_negative_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-1,2,-4")); };

        It should_return_an_exception_listing_them = () => { _result.Message.Should().Be("negatives not allowed: -1, -4"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_input_contains_larger_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };  

        Because of = () => { _result = _systemUnderTest.Add("1,2,1800,1000"); };

        It should_sum_only_the_numbers_less_than_or_equal_1000 = () => { _result.Should().Be(1003); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_a_custom_multicharacter_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[###]\n3###3###3###1"); };

        It should_split_by_that_delimiter_and_return_the_sum = () => { _result.Should().Be(10); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_multiple_custom_delimiters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[**][%]\n1**2%3"); };

        It should_return_the_sum = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }
    
    
}

/*
11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[**][%]\n1**2%3” should return 6)

 */