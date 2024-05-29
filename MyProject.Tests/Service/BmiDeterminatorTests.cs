namespace MyProject.Tests;

public class BmiDeterminatorTests
{

    [Theory]
    [InlineData(10, BmiClassification.Underweight)]
    [InlineData(12, BmiClassification.Underweight)]
    [InlineData(18.5, BmiClassification.Normal)]
    [InlineData(24, BmiClassification.Normal)]
    [InlineData(22, BmiClassification.Normal)]
    [InlineData(18.6, BmiClassification.Normal)]
    [InlineData(29.7, BmiClassification.Overweight)]
    [InlineData(25, BmiClassification.Overweight)]
    [InlineData(34.9, BmiClassification.Obesity)]
    [InlineData(30, BmiClassification.Obesity)]
    [InlineData(34, BmiClassification.Obesity)]
    [InlineData(40, BmiClassification.ExtremeObesity)]
    [InlineData(37, BmiClassification.ExtremeObesity)]
    [InlineData(39, BmiClassification.ExtremeObesity)]
    public void DetermineBmi_ForGivenBmiBelow_ReturnsUnderweight(double bmi, BmiClassification expected)
    {
        // arrange
        //double bmi = 18;
        var bmiDeterminator = new BmiDeterminator();

        // act
        BmiClassification bmiClassification = bmiDeterminator.DetermineBmi(bmi);

        // assert
        Assert.Equal(expected, bmiClassification);
    }
}
