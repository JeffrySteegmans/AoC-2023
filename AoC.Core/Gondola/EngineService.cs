using System.Text.RegularExpressions;

namespace AoC.Core.Gondola;

public interface IEngineService
{
    int CalculatePartNumberSum();

    int CalculateSumOfGearRatios();
}


public partial class EngineService : IEngineService
{
    private readonly IEnumerable<Part> _symbols = Enumerable.Empty<Part>();
    private readonly IEnumerable<Part> _numbers = Enumerable.Empty<Part>();
    private readonly IEnumerable<Part> _gears = Enumerable.Empty<Part>();

    [GeneratedRegex(@"[^.0-9]")]
    private static partial Regex SymbolRegex();

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    [GeneratedRegex(@"[*]")]
    private static partial Regex GearRegex();

    public EngineService(IEnumerable<string> input)
    {
        _symbols = ParseParts(input, SymbolRegex());
        _numbers = ParseParts(input, NumberRegex());
        _gears = ParseParts(input, GearRegex());
    }

    public int CalculatePartNumberSum()
    {
        return _numbers
            .Where(numberPart => _symbols.Any(symbolPart => Adjacent(numberPart, symbolPart)))
            .Sum(numberPart => int.Parse(numberPart.Value));
    }

    public int CalculateSumOfGearRatios()
    {
        return _gears
            .Select(gearPart => _numbers.Where(numberPart => Adjacent(numberPart, gearPart)))
            .Where(numberParts => numberParts.Count() > 1)
            .Select(numberParts => numberParts.Select(x => int.Parse(x.Value)).Aggregate((x, y) => x * y))
            .Sum();
    }

    private bool Adjacent(Part number, Part symbol)
    {
        return Math.Abs(number.Y - symbol.Y) <= 1
            && symbol.X >= number.X - 1
            && symbol.X <= number.X + number.Value.Length;

    }

    private IEnumerable<Part> ParseParts(IEnumerable<string> input, Regex regex)
    {
        return input
            .SelectMany((line, row) => ParsePart(line, row, regex));
    }

    private IEnumerable<Part> ParsePart(string line, int row, Regex regex)
    {
        return regex
            .Matches(line)
            .Select(match => new Part(match.Value, match.Index, row));
    }
}
