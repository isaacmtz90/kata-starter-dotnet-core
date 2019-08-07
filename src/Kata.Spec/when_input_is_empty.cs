using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_input_is_empty
    {
        private Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_0 = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_one_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("3"); };

        It should_return_that_number = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_two_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("3,4"); };

        It should_return_the_sum_of_those_numbers = () => { _result.Should().Be(7); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_unknown_amount_of_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };

        It should_return_the_sum_of_all = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_delimiter_includes_newlines
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2\n3"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_given_a_custom_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2;3"); };

        It should_return_the_sum_of_the_delimited_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_has_a_negative_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,2,-3")); };

        It should_throw_an_exception_listing_that_number = () =>
        {
            _result.Message.Should().Be("negatives not allowed: -3");
        };

        private static Calculator _systemUnderTest;
        private static Exception _result;
    }

    public class when_multiple_negatives_in_the_input
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2,-3,-4")); };

        It should_throw_exception_listing_all = () =>
        {
            _result.Message.Should().Be("negatives not allowed: -2, -3, -4");
        };

        private static Calculator _systemUnderTest;
        private static Exception _result;
    }

    public class when_input_has_numbers_larger_than_1000
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,1000,3,1001"); };

        It should_not_add_them_up = () => { _result.Should().Be(1004); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_multichar_custom_delimiter_is_provided
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("//[$$$]\n1$$$2$$$3"); };

        It should_use_it_to_split_and_return_the_sum = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_given_multiple_multichar_delimiters
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("//[**][%]\n1**2%3"); };

        It should_properly_split_and_sum_the_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }
}

