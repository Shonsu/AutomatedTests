using System.Diagnostics;
using FluentAssertions;
using Moq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MyProject.Tests;

public class BmiCalculatorFacadeTests
{
    private const string UNDERWEIGHT_SUMMARY = "You are underweight, you should put on some weight";
    private const string NORMAL_SUMMARY = "Your weight is normal, keep it up";
    private const string OVERWEIGHT_SUMMARY = "You are a bit overweight";
    private const string OBESITY_SUMMARY = "You should take care of your obesity";
    private const string EXTREMEOBESITY_SUMMARY = "Your extreme obesity might cause health problems";

    private readonly ITestOutputHelper _outputHelper;

    public BmiCalculatorFacadeTests(ITestOutputHelper testOutputHelper)
    {
        _outputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData(BmiClassification.Underweight, UNDERWEIGHT_SUMMARY)]
    [InlineData(BmiClassification.Normal, NORMAL_SUMMARY)]
    [InlineData(BmiClassification.Overweight, OVERWEIGHT_SUMMARY)]
    [InlineData(BmiClassification.Obesity, OBESITY_SUMMARY)]
    [InlineData(BmiClassification.ExtremeObesity, EXTREMEOBESITY_SUMMARY)]
    public void GetResult_ForValidInputs_ReturnCorrectSummary(BmiClassification bmiClassification, String summary)
    {
        // arrange
        var bmiDeterminatorMock = new Mock<IBmiDeterminator>();
        bmiDeterminatorMock.Setup(b => b.DetermineBmi(It.IsAny<double>())).Returns(bmiClassification);
        BmiCalculatorFacade facade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeterminatorMock.Object);

        // act
        BmiResult result = facade.GetResult(1, 1);
        _outputHelper.WriteLine($"{bmiClassification} : {result.Summary}");
        // assert
        result.Summary.Should().Be(summary);
    }
}
