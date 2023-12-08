using AoC.Core.BoatRace;

namespace AoC.Core.Tests.BoatRaceServiceTests;

public sealed class CalculateNumberOfWaysToBeatTheRecordTests
{
    [Fact]
    public void ShouldReturnCorrectNumberOfWaysToBeatTheRecord()
    {
        var input = new List<string>
        {
            "Time:      7  15   30",
            "Distance: 9  40  200",
        };
        var expectedResult = 71503;

        var service = new BoatRaceService(input);

        var result = service.CalculateNumberOfWaysToBeatTheRecord();

        result.Should().Be(expectedResult);
    }
}
