using Exercise;
using FluentAssertions;

namespace Escercise.Tests;

public class ListHelperTests
{

    [Fact]
    public void FilterOddNumber_WithGivenIntArray_ShoulReturnOnlyOddNumbers()
    {
        // arrange
        List<int> input = new List<int>() { 1, 2, 2, 3, 5, 8, 8, 8, 9 };
        List<int> expected = new List<int>() { 1, 3, 5, 9 };

        // act
        List<int> result = ListHelper.FilterOddNumber(input);

        // assert
        result.Should().Equal(expected);
    }
}
