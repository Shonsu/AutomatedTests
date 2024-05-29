using FluentAssertions;
using Moq;
using MyProject.Service;

namespace MyProject.Tests;

public class ResultServiceTests
{

    [Fact]
    public void SetRecentOverweightResultTest_ForOverweightResult_UpdatesProperty()
    {
        // arrange 
        var result = new BmiResult()
        {
            BmiClassification = BmiClassification.Overweight
        };
        var resultRepositoryMock = new Mock<ResultRepository>();
        var resultService = new ResultService(resultRepositoryMock.Object);
        // act
        resultService.SetRecentOverweightResult(result);

        // assert
        resultService.RecentOverweightResult.Should().Be(result);
    }

    [Theory]
    [InlineData(BmiClassification.ExtremeObesity)]
    [InlineData(BmiClassification.Normal)]
    [InlineData(BmiClassification.Obesity)]
    [InlineData(BmiClassification.Underweight)]
    public void SetRecentOverweightResultTest_ForNotOverweightResult_DoesNotUpdateProperty(BmiClassification bmiClassification)
    {
        // arrange 
        var result = new BmiResult()
        {
            BmiClassification = bmiClassification
        };
        var resultRepositoryMock = new Mock<IResultRepository>();
        var resultService = new ResultService(resultRepositoryMock.Object);
        // act
        resultService.SetRecentOverweightResult(result);

        // assert
        resultService.RecentOverweightResult.Should().BeNull();
    }

    [Fact]
    public async Task SaveUnderweightResultAsync_ForUnderweightResult_InvokesSaveResultAsync()
    {
        // arrange
        var result = new BmiResult()
        {
            BmiClassification = BmiClassification.Underweight
        };
        var resultRepositoryMock = new Mock<IResultRepository>();
        // resultRepositoryMock.Setup( rr => rr.SaveResultAsync(It.IsAny<BmiResult>()))
        var resultService = new ResultService(resultRepositoryMock.Object);

        // act
        await resultService.SaveUnderweightResultAsync(result);
        // assert

        resultRepositoryMock.Verify(mock => mock.SaveResultAsync(result), Times.Once);
    }

    [Fact]
    public async Task SaveUnderweightResultAsync_ForNotUnderweightResult_NotInvokesSaveResultAsync()
    {
        // arrange
        var result = new BmiResult()
        {
            BmiClassification = BmiClassification.Normal
        };
        var resultRepositoryMock = new Mock<IResultRepository>();
        // resultRepositoryMock.Setup( rr => rr.SaveResultAsync(It.IsAny<BmiResult>()))
        var resultService = new ResultService(resultRepositoryMock.Object);

        // act
        await resultService.SaveUnderweightResultAsync(result);
        // assert

        resultRepositoryMock.Verify(mock => mock.SaveResultAsync(result), Times.Never);
    }
}
