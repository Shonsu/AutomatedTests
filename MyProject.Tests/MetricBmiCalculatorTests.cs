﻿using System.Runtime.InteropServices;

namespace MyProject.Tests;

public class MetricBmiCalculatorTests
{
    private const string NOTVALID_WEIGHT_EX_MESSAGE = "Weight is not a valid number";
    private const string NOTVALID_HEIGHT_EX_MESSAGE = "Height is not a valid number";

    public static IEnumerable<object[]> GetSampleData()
    {
        yield return new object[] { 100, 170, 34.6 };
        yield return new object[] { 57, 170, 19.72 };
        yield return new object[] { 70, 170, 24.22 };
        yield return new object[] { 77, 160, 30.08 };
        yield return new object[] { 80, 190, 22.16 };
        yield return new object[] { 90, 190, 24.93 };
    }

    [Theory]
    // [InlineData(100, 170, 34.6)] for example purpose
    [MemberData(nameof(GetSampleData))]
    public void CalculateBmi_ForGivenWeigthAndHeight_ReturnCorrectBmi(double weight, double height, double bmiResult)
    {
        //arrange
        MetricBmiCalculator bmiCalculator = new MetricBmiCalculator();
        //act
        double result = bmiCalculator.CalculateBmi(weight, height);
        //assert
        Assert.Equal(bmiResult, result);
    }

    [Theory]
    [InlineData(-50)]
    [InlineData(-123)]
    [InlineData(0)]
    [InlineData(-70)]
    public void CalculateBmi_ForIvalidWeightAndValidHeight_ThrowsArgumentException(double weight)
    {
        // arrange
        double height = 180;
        MetricBmiCalculator bmiCalculator = new MetricBmiCalculator();

        // act
        Action action = () => bmiCalculator.CalculateBmi(weight, height);

        // assert
        ArgumentException ex = Assert.Throws<ArgumentException>(action);
        Assert.Equal(NOTVALID_WEIGHT_EX_MESSAGE, ex.Message);
    }

    [Theory]
    [InlineData(-160)]
    [InlineData(-182)]
    [InlineData(-123)]
    [InlineData(0)]
    public void CalculateBmi_ForIvalidHeightAndValidWeight_ThrowsArgumentException(double height)
    {
        // arrange
        double weight = 90;
        MetricBmiCalculator bmiCalculator = new MetricBmiCalculator();

        // act
        Action action = () => bmiCalculator.CalculateBmi(weight, height);

        // assert
        ArgumentException ex = Assert.Throws<ArgumentException>(action);
        Assert.Equal(NOTVALID_HEIGHT_EX_MESSAGE, ex.Message);
    }

}
