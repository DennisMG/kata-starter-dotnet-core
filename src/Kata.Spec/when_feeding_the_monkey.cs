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
        private Establish _context = () =>
            _systemUnderTest = new Calculator();
        
        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_is_one_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3"); };

        It should_return_that_same_number = () => { _result.Should().Be(3); };
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

        It should_return_the_sum = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_an_unknown_amount_of_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };

        It should_return_the_sum = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_new_line_and_comma_delimiters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1\n2,3"); };

        It should_should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_a_custom_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2;3"); };

        It should_parse_the_delimiter_and_return_the_sum_of_the_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_contains_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        private Because of = () => { _result = Catch.Exception((() => { _systemUnderTest.Add("-1,2,3"); }));};

        It should_throw_exception = () => { _result.Message.Should().Be("negatives not allowed: -1"); };
        private static Calculator _systemUnderTest;
        private static Exception _result;
    }

    public class when_input_contains_multiple_negatives
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2,-3")); };

        It should_throw_an_exception_listing_them = () => { _result.Message.Should().Be("negatives not allowed: -2, -3"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_input_contains_numbers_larger_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,1001,1000"); };

        It should_sum_only_numbers_less_than_1000 = () => { _result.Should().Be(1001); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_contains_a_multicharacter_custom_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[###]\n4###5###1"); };

        It should_return_the_sum_of_all_delimited_numbers = () => { _result.Should().Be(10); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_multiple_custom_delimiters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[**][%]\n1**2%3"); };

        It should_return_the_sum_of_all_numberas = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }
    
}

/*
11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[**][%]\n1**2%3” should return 6)

 */