using AoC.Core.Gondola;
using FluentAssertions;

namespace AoC.Core.Tests.Gondola;

public sealed class CalculatePartNumberSumTests
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
        var expectedSum = 4361;

        var engineService = new EngineService(input);

        var sum = engineService.CalculatePartNumberSum();

        sum.Should().Be(expectedSum);
    }
}
