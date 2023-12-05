using FluentAssertions;

namespace AoC.Core.Tests.CalibrationServiceTests;

public sealed class CalculateCalibrationValueWithSpelledOutNumbersTests
{
    [Fact]
    public void ShouldReturnCorrectCalibrationValue()
    {
        var encodedCalibration = new List<string>
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };
        var expectedResult = 281;

        var sut = new CalibrationService();

        var result = sut.CalculateCalibrationValueWithSpelledOutNumbers(encodedCalibration);

        result
            .Should().Be(expectedResult);
    }
}
