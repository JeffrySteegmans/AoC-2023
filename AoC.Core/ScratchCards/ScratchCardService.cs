using System.Text.RegularExpressions;

namespace AoC.Core.ScratchCards;

public interface IScratchCardService
{
    int CalculateTotalPoints();

    int CalculateTotalCopies();
}

public sealed partial class ScratchCardService
    : IScratchCardService
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    private readonly IEnumerable<ScratchCard> _scratchCards = Enumerable.Empty<ScratchCard>();

    public ScratchCardService(IEnumerable<string> input)
    {
        _scratchCards = input.Select(ParseScratchCard);
    }

    public int CalculateTotalPoints()
    {
        return _scratchCards
            .Select(scratchCard => (int)Math.Pow(2, scratchCard.MatchingNumbers - 1))
            .Sum();
    }

    public int CalculateTotalCopies()
    {
        var cards = _scratchCards.ToArray();
        var counts = _scratchCards.Select(_ => 1).ToArray();

        for (int i = 0; i < _scratchCards.Count(); i++)
        {
            var card = cards[i];
            var count = counts[i];

            for (int j = 1; j <= card.MatchingNumbers; j++)
            {
                counts[i + j] += count;
            }
        }

        return counts.Sum();
    }

    private ScratchCard ParseScratchCard(string line)
    {
        var parts = line.Split(':', '|');
        var winningNumbers = NumberRegex()
            .Matches(parts[1])
            .Select(x => int.Parse(x.Value));
        var numbers = NumberRegex()
            .Matches(parts[2])
            .Select(x => int.Parse(x.Value));

        return new ScratchCard(winningNumbers, numbers);
    }
}
