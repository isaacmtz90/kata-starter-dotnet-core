using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_input_is_empty
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
}