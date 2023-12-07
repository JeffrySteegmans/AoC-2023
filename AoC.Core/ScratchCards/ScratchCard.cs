namespace AoC.Core.ScratchCards;

internal record ScratchCard(IEnumerable<int> WinningNumbers, IEnumerable<int> Numbers)
{
    public int MatchingNumbers => WinningNumbers.Intersect(Numbers).Count();
};
