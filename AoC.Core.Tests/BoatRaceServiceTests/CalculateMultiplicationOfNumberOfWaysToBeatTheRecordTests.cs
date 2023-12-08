using AoC.Core.BoatRace;

namespace AoC.Core.Tests.BoatRaceServiceTests;

public sealed class CalculateMultiplicationOfNumberOfWaysToBeatTheRecordTests
{
    [Fact]
    public void ShouldReturnCorrectMultiplication()
    {
        var input = new List<string>
        {
            "Time:      7  15   30",
            "Distance: 9  40  200",
        };
        var expectedResult = 288;

        var service = new BoatRaceService(input);

        var result = service.CalculateMultiplicationOfNumberOfWaysToBeatTheRecord();

        result.Should().Be(expectedResult);
    }
}
