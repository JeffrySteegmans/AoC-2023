namespace AoC.Core.CamelCards;

public interface ICamelCardsService
{
    long CalculateWinnings();
}

public sealed class CamelCardsService(List<string> input)
        : ICamelCardsService
{
    private readonly List<Game> _games = input
            .Select(x => x.Split(' '))
            .Select(x => new Game(x[0], int.Parse(x[1])))
            .ToList();

    public long CalculateWinnings()
    {
        var patternValue = _games
            .Select(game =>
            {
                return (game.Hand
                    .Select(ch => game.Hand.Count(x => x == ch))
                    .Sum(), game);
            })
            .OrderByDescending(x => x.Item1)
            .Select(x => x.game)
            .ToList();

        //TODO: Order games by ranking

        throw new NotImplementedException();
    }
}

public record Game(string Hand, int Bid);
