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
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_is_one_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("3"); };

        It should_return_that_same_number = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_adding_two_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,3"); };

        It should_return_the_sum_of_both_numbers = () => { _result.Should().Be(4); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_has_an_unknown_amount_of_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2,5"); };

        It should_return_the_sum_of_all_of_them = () => { _result.Should().Be(8); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_using_a_new_line_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2\n3"); };

        It should_return_the_sum_of_the_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_contains_a_custom_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("//;\n3;2"); };

        It should_split_the_numbers_by_that_delimiter_and_return_the_sum = () => { _result.Should().Be(5); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_includes_one_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(()=> _systemUnderTest.Add("1,-2,3")); };

        It should_throw_an_exception = () => { _result.Message.Should().Be("negatives not allowed: -2"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_input_contains_multiple_negative_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-2,-1,4")); };

        It should_throw_an_exception_listing_them_all = () => { _result.Message.Should().Be("negatives not allowed: -2, -1"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_user_input_includes_numbers_larger_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3,1001"); };

        It should_ignore_large_numbers_and_return_the_sum_of_the_rest = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }
}

// 9. Given the user input contains numbers larger than 1000 when calculating the sum it should only sum the numbers less than 1001. (example 2 + 1001 = 2)
// 10. Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[***]\n1***2***3” should return 6)
// 11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)