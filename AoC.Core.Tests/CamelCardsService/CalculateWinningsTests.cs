using AoC.Core.CamelCards;

namespace AoC.Core.Tests.CamelCardsServiceTests;

public sealed class CalculateWinningsTests
{
    [Fact]
    public void ShouldReturnCorrectWinnings()
    {
        var input = new List<string>
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483",
        };
        var expectedResult = 6440;

        var service = new CamelCardsService(input);

        var result = service.CalculateWinnings();

        result.Should().Be(expectedResult);
    }
}
