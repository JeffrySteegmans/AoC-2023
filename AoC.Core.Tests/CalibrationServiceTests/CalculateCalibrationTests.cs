using FluentAssertions;

namespace AoC.Core.Tests.CalibrationServiceTests;

public sealed class CalculateCalibrationTests
{
    [Fact]
    public void ShouldReturnCorrectCalibrationValue()
    {
        var encodedCalibration = new List<string>
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };
        var expectedResult = 142;

        var sut = new CalibrationService();

        var result = sut.CalculateCalibrationValue(encodedCalibration);

        result
            .Should().Be(expectedResult);
    }

    [Fact]
    public void ShouldReturnCorrectCalibrationValue_WhenInputContainsDoubleDigit()
    {
        var encodedCalibration = new List<string>
        {
            "lblcscglvseven53251zzcj"
        };
        var expectedResult = 51;

        var sut = new CalibrationService();

        var result = sut.CalculateCalibrationValue(encodedCalibration);

        result
            .Should().Be(expectedResult);
    }
}
