using FluentAssertions;

namespace MyProject.Tests;

public class BmiCalculatorFacadeTests
{
    private const string OVERWEIGHT_SUMMARY = "You are a bit overweight";

    [Fact]
    public void GetResult_ForValidInputs_ReturnCorrectResult()
    {
        // arrange
        IBmiDeterminator bmiDeterminator = new BmiDeterminator();
        BmiCalculatorFacade facade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeterminator);
        double weight = 90;
        double height = 190;

        // act
        BmiResult result = facade.GetResult(weight, height);

        // assert
        // Assert.Equal(BmiClassification.Overweight, result.BmiClassification);
        // Assert.Equal(24.93, result.Bmi);
        // Assert.Equal(OVERWEIGHT_SUMMARY, result.Summary);
        result.Bmi.Should().Be(24.93);
        result.BmiClassification.Should().Be(BmiClassification.Overweight);
        result.Summary.Should().Be(OVERWEIGHT_SUMMARY);
    }
}
