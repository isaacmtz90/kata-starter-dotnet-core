﻿using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec.when_calculating_the_sum
{
    public class when_the_user_input_is_empty
    {
        static Calculator _systemUnderTest;
        static int _result;

        Establish context = () =>
            _systemUnderTest = new Calculator();

        Because of = () =>
            _result = _systemUnderTest.Add("");

        It should_return_zero = () =>
            _result.Should().Be(0);
    }

    public class when_the_input_is_one_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("3"); };

        It should_return_that_number = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_two_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2"); };

        It should_return_the_sum_of_those_two_numbers = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_many_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_the_user_input_has_new_lines_for_delimiters
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2\n3"); };

        It should_return_the_sum_of_the_numbers = () => { _result.Should().Be(6); };

        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_the_input_has_a_custom_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;3"); };

        It should_return_the_sum_of_the_numbers = () => { _result.Should().Be(4); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_the_input_contains_one_negative_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,2,-3")); };

        It should_throw_an_exception_containing_the_negative_number = () =>
        {
            _result.Message.Should().Be("negatives not allowed: -3");
        };

        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_the_input_has_multiple_negative_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception( () =>  _systemUnderTest.Add("1,2,-3,-4")); };

        It should_throw_an_exception_listing_them_all = () => { _result.Message.Should().Be("negatives not allowed: -3, -4"); };
        private static Calculator _systemUnderTest;
        private static Exception _result;
    }


//    8. Given the user input contains multiple negative numbers mixed with positive numbers when calculating the sum then it should throw an exception "negatives not allowed: x, y, z" (where x, y, z are only the negative numbers). 
//    9. Given the user input contains numbers larger than 1000 when calculating the sum it should only sum the numbers less than 1001. (example 2 + 1001 = 2)
//    10. Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[***]\n1***2***3” should return 6)
//    11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)
}