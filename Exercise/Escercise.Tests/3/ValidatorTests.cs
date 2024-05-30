using Exercise;
using FluentAssertions;

namespace Escercise.Tests;

public class ValidatorTests
{
    [Theory]
    [MemberData(nameof(DataResultsTrue))]
    public void ValidateOverlapping_WithNonOverlappingRangeListAndInput_ShouldReturnTrue(List<DateRange> dateRanges, DateRange input)
    {
        // arrange
        var validator = new Validator();

        // act
        bool result = validator.ValidateOverlapping(dateRanges, input);

        // assert
        result.Should().BeTrue();
    }

    public static IEnumerable<object[]> DataResultsTrue()
    {
        yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2000, 10, 1), new DateTime(2000, 10, 5)), new DateRange(new DateTime(2000, 10, 11), new DateTime(2000, 10, 15)) },
                                                            new DateRange(new DateTime(2000, 10, 6), new DateTime(2000, 10, 10)) };
        yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2001, 10, 1), new DateTime(2001, 10, 5)), new DateRange(new DateTime(2002, 10, 11), new DateTime(2002, 10, 15)) },
                                                            new DateRange(new DateTime(2001, 10, 6), new DateTime(2002, 10, 10)) };
        yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2005, 10, 1), new DateTime(2006, 10, 5)), new DateRange(new DateTime(2004, 10, 11), new DateTime(2005, 10, 15)) },
                                                            new DateRange(new DateTime(2000, 10, 6), new DateTime(2004, 10, 10)) };
        yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2005, 10, 1), new DateTime(2004, 09, 30)), new DateRange(new DateTime(2004, 10, 2), new DateTime(2005, 10, 15)) },
                                                            new DateRange(new DateTime(2004, 10, 1), new DateTime(2004, 10, 1)) };
    }

    [Theory]
    [MemberData(nameof(DataResultsFalse))]
    public void ValidateOverlapping_WithOverlappingRangeListAndInput_ShouldReturnFalse(List<DateRange> dateRanges, DateRange input)
    {
        // arrange
        var validator = new Validator();

        // act
        bool result = validator.ValidateOverlapping(dateRanges, input);

        // assert
        result.Should().BeFalse();
    }

    public static IEnumerable<object[]> DataResultsFalse()
    {
        yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2000, 10, 1), new DateTime(2000, 10, 5)), new DateRange(new DateTime(2000, 10, 11), new DateTime(2000, 10, 15)) },
                                                            new DateRange(new DateTime(2000, 10, 5), new DateTime(2000, 10, 10)) };
        yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2001, 10, 1), new DateTime(2001, 10, 5)), new DateRange(new DateTime(2002, 10, 11), new DateTime(2002, 10, 15)) },
                                                            new DateRange(new DateTime(2001, 9, 6), new DateTime(2002, 12, 10)) };
        yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2005, 10, 1), new DateTime(2006, 10, 5)), new DateRange(new DateTime(2004, 10, 11), new DateTime(2005, 10, 15)) },
                                                            new DateRange(new DateTime(2005, 1, 6), new DateTime(2004, 10, 10)) };
        yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2005, 10, 1), new DateTime(2006, 10, 5)), new DateRange(new DateTime(2004, 10, 11), new DateTime(2005, 10, 15)) },
                                                            new DateRange(new DateTime(2004, 1, 6), new DateTime(2005, 10, 10)) };
    }



    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ValidateOverlapping_WithOverlappingRangeListAndInput_ShouldReturnFalse_SECOND_WAY(int index)
    {
        // arrange
        var validator = new Validator();
        List<DateRange> dateRanges = _rangeList[index];
        DateRange input = new DateRange(new DateTime(2000, 10, 5), new DateTime(2000, 11, 10));
        // act
        bool result = validator.ValidateOverlapping(dateRanges, input);

        // assert
        result.Should().BeFalse();
    }

    private List<List<DateRange>> _rangeList = new List<List<DateRange>>()
    {
        new List<DateRange>() { new DateRange(new DateTime(2000, 8, 1), new DateTime(2000, 12, 15)), new DateRange(new DateTime(2000, 10, 1), new DateTime(2000, 12, 15)) },
        new List<DateRange>() { new DateRange(new DateTime(2000, 3, 1), new DateTime(2000, 10, 8)), new DateRange(new DateTime(2000, 4, 11), new DateTime(2000, 11, 5)) },
        new List<DateRange>() { new DateRange(new DateTime(2000, 10, 1), new DateTime(2000, 12, 5)), new DateRange(new DateTime(2000, 1, 11), new DateTime(2000, 12, 15)) },
        new List<DateRange>() { new DateRange(new DateTime(2000, 10, 6), new DateTime(2000, 10, 30)), new DateRange(new DateTime(2000, 10, 30), new DateTime(2000, 11, 5)) },
    };
}
