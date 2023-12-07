using AoC.Core.Gondola;

namespace AoC.Core.Tests.Gondola;

public sealed class CalculateSumOfGearRatiosTests
{
    [Fact]
    public void ShouldReturnCorrectSum()
    {
        var input = new List<string>
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };
        var expectedSum = 467835;

        var engineService = new EngineService(input);

        var sum = engineService.CalculateSumOfGearRatios();

        sum.Should().Be(expectedSum);
    }
}
