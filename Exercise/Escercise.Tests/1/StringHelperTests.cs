using Exercise;
using FluentAssertions;

namespace Escercise.Tests;

public class StringHelperTests
{
    [Theory]
    [InlineData("I'm going tomorrow to work", "work to tomorrow going I'm")]
    [InlineData("Hanna has a cat", "cat a has Hanna")]
    [InlineData("I will come to New York on wednesday", "wednesday on York New to come will I")]
    public void ReverseWords_ForGivenSentence_ReturnReversedSentence(string sentence, string expected)
    {
        // arrange

        // act
        string result = StringHelper.ReverseWords(sentence);

        //assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("ala")]
    [InlineData("kajak")]
    [InlineData("radar")]
    public void IsPalindrome_ForGivenPalindromes_ShouldReturnTrue(string stringToCheck)
    {
        // arrange

        // act
        bool result = StringHelper.IsPalindrome(stringToCheck);

        // assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("pole")]
    [InlineData("namiot")]
    [InlineData("tester")]
    public void IsPalindrome_ForGivenANonPalindromes_ShouldReturnFalse(string stringToCheck)
    {
        // arrange

        // act
        bool result = StringHelper.IsPalindrome(stringToCheck);

        // assert
        result.Should().BeFalse();
    }
}