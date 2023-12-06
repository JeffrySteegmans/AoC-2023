using System.Text.RegularExpressions;

namespace AoC.Core.Cubes;

public interface IGameService
{
    int CalculateSumFromValidGameIds();

    int CalculateSumFromPower();
}

public partial class GameService : IGameService
{
    const int MaxRed = 12;
    const int MaxGreen = 13;
    const int MaxBlue = 14;

    [GeneratedRegex(@"Game (\d+)")]
    private static partial Regex GameIdRegex();

    [GeneratedRegex(@"(\d+) red")]
    private static partial Regex RedRegex();

    [GeneratedRegex(@"(\d+) green")]
    private static partial Regex GreenRegex();

    [GeneratedRegex(@"(\d+) blue")]
    private static partial Regex BlueRegex();

    private readonly IEnumerable<Game> _games = Enumerable.Empty<Game>();

    public GameService(List<string> input)
    {
        _games = input
            .Select(ParseGame);
    }

    public int CalculateSumFromValidGameIds()
    {
        return _games
            .Where(IsValid)
            .Select(game => game.Id)
            .Sum();
    }

    public int CalculateSumFromPower()
    {
        return _games
            .Select(game => new { maxRed = game.Red.Max(), maxGreen = game.Green.Max(), maxBlue = game.Blue.Max() })
            .Select(x => x.maxRed * x.maxGreen * x.maxBlue)
            .Sum();
    }

    private Game ParseGame(string line)
    {
        return new Game(
            ParseInts(line, GameIdRegex()).First(),
            ParseInts(line, RedRegex()),
            ParseInts(line, GreenRegex()),
            ParseInts(line, BlueRegex())
        );
    }

    private static List<int> ParseInts(string line, Regex regex)
    {
        return regex.Matches(line)
            .Select(x => x.Groups[1].Value)
            .Select(int.Parse)
            .ToList();
    }

    private static bool IsValid(Game game)
    {
        return game.Red.Max() <= MaxRed
            && game.Green.Max() <= MaxGreen
            && game.Blue.Max() <= MaxBlue;
    }
}
