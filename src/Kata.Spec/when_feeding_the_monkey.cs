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

        It should_return_0 = () => { _result.Should().Be(0); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_one_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1"); };

        It should_return_that_number = () => { _result.Should().Be(1); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_two_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("3,4"); };

        It should_return_the_sum_of_them = () => { _result.Should().Be(7); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_adding_an_unknown_amount_of_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };

        It should_return_the_sum_of_all_the_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_includes_newline_as_a_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2\n3"); };

        It should_split_and_sum_all_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_includes_a_custom_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2;3"); };

        It should_return_the_sum_of_the_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_includes_one_negative_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,2,-3")); };

        It should_throw_an_exception_showing_that_number = () =>
        {
            _result.Message.Should().Be("negatives not allowed: -3");
        };

        static Exception _result;
        static Calculator _systemUnderTest;
    }

    public class when_input_includes_multiple_negative_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2,3,-4")); };

        It should_throw_an_exception_listing_all_the_negatives = () =>
        {
            _result.Message.Should().Be("negatives not allowed: -2, -4");
        };

        static Exception _result;
        static Calculator _systemUnderTest;
    }

    public class when_user_input_contains_numbers_larger_than_1000
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2,1000,1001"); };

        It should_only_sum_the_numbers_less_than_1k = () => { _result.Should().Be(1003); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_includes_a_multi_character_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };

        It should_return_the_sum_of_the_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_contains_multiple_multicharacter_delimiters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[*][%]\n1*2%3"); };

        It should_split_and_sum_the_valid_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }
}
// 11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)