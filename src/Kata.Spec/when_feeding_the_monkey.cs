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

    public class when_user_input_is_empty
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_0 = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_one_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3"); };

        It should_return_the_same_number = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_is_two_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("2,3"); };

        It should_split_by_comma_and_return_the_sum = () => { _result.Should().Be(5); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_unknown_amount_of_numberas
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3,4"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(10); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_delimited_by_comma_and_newline
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2\n3"); };

        It should_split_and_return_the_sum = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_multiple_numbers_with_a_custom_single_charater_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };

        It should_return_the_sum_of_all_numberas = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_contains_one_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,2,-3")); };

        It should_return_return_an_exception_listing_the_number = () => { _result.Message.Should().Be("negatives not allowed: -3"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_input_contains_multiple_negative_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-1,2,-3")); };

        It should_throw_exception = () => { _result.Message.Should().Be("negatives not allowed: -1, -3"); };
        private static Calculator _systemUnderTest;
        private static Exception _result;
    }

    public class when_input_contains_numbers_larger_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,1000,2,1002"); };

        It should_not_sum_those_numbers_to_the_result = () => { _result.Should().Be(1003); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_multicharacter_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };

        It should_should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
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

        It should_split_and_return_the_sum = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }
}

/*
11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[**][%]\n1**2%3” should return 6)

 */