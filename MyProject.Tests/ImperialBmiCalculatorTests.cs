namespace MyProject.Tests;

public class ImperialBmiCalculatorTests
{
    [Theory]
    [InlineData(100, 170, 2.43)]
    [InlineData(57, 170, 1.39)]
    [InlineData(70, 170, 1.7)]
    [InlineData(77, 160, 2.11)]
    [InlineData(80, 190, 1.56)]
    [InlineData(90, 190, 1.75)]
    public void CalculateBmi_ForGivenWeigthAndHeight_ReturnCorrectBmi(double weight, double height, double bmiResult)
    {
        //arrange
        ImperialBmiCalculator bmiCalculator = new ImperialBmiCalculator();
        System.Diagnostics.Debug.WriteLine($"{weight} {height}:" + Math.Round((weight / Math.Pow(height, 2) * 703), 2));
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
        ImperialBmiCalculator bmiCalculator = new ImperialBmiCalculator();

        // act
        Action action = () => bmiCalculator.CalculateBmi(weight, height);

        // assert
        ArgumentException ex = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Weight is not a valid number", ex.Message);
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
        ImperialBmiCalculator bmiCalculator = new ImperialBmiCalculator();

        // act
        Action action = () => bmiCalculator.CalculateBmi(weight, height);

        // assert
        ArgumentException ex = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Height is not a valid number", ex.Message);
    }
}
