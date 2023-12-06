using AoC.Core.Cubes;
using FluentAssertions;

namespace AoC.Core.Tests.Cubes.GameServiceTests;

public sealed class CalculateSumFromPowerTests
{
    [Fact]
    public void ShouldReturnCorrectSum()
    {
        var input = new List<string>
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };
        var expectedResult = 2286;

        var sut = new GameService(input);

        var result = sut.CalculateSumFromPower();

        result
            .Should().Be(expectedResult);
    }
}
