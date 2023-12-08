using System.Text.RegularExpressions;

namespace AoC.Core.Almanac;

public interface IAlmanacService
{
    long CalculateLowestLocationNumber();

    long CalculateLowestLocationNumberFromSeedRanges();
}

public partial class AlmanacService
    : IAlmanacService
{
    [GeneratedRegex(@"(\d+)")]
    private static partial Regex NumberRegex();

    private readonly List<Range> _seeds = [];
    private readonly List<Range> _seedRanges = [];
    private readonly List<Dictionary<Range, Range>> _maps = [];

    public AlmanacService(string input)
    {
        var blocks = input.Split("\r\n\r\n");

        ParseSeeds(blocks.First());

        _maps = blocks
            .Skip(1)
            .Select(ParseMap)
            .ToList();
    }

    private void ParseSeeds(string seedLine)
    {
        _seeds.AddRange(
            NumberRegex()
                .Matches(seedLine)
                .Select(x => long.Parse(x.Value))
                .Select(x => new Range(x, x))
        );

        _seedRanges.AddRange(
            NumberRegex()
                .Matches(seedLine)
                .Select(x => long.Parse(x.Value))
                .Chunk(2)
                .Select(x => new Range(x[0], x[0] + x[1]))
        );
    }

    private Dictionary<Range, Range> ParseMap(string input)
    {
        return input
            .Split("\n")
            .Skip(1)
            .Select(line =>
            {
                var values = NumberRegex().Matches(line).Select(x => long.Parse(x.Value)).ToArray();
                var sourceStart = values[1];
                var destinationStart = values[0];
                var range = values[2];
                var destinationRange = new Range(destinationStart, destinationStart + range - 1);
                var sourceRange = new Range(sourceStart, sourceStart + range - 1);

                return new KeyValuePair<Range, Range>(sourceRange, destinationRange);
            })
            .ToDictionary();
    }

    public long CalculateLowestLocationNumber()
    {
        return _maps
            .Aggregate(_seeds, Project)
            .Select(x => x.From)
            .Min();
    }

    private List<Range> Project(List<Range> seeds, Dictionary<Range, Range> map)
    {
        var todo = new Queue<Range>();
        foreach (var seed in seeds)
        {
            todo.Enqueue(seed);
        }

        var result = new List<Range>();
        while (todo.Any())
        {
            var seedRange = todo.Dequeue();

            var mapSourceRange = map.Keys.FirstOrDefault(x => InterSect(x, seedRange));

            if (mapSourceRange is null)
            {
                // No intersection found => Add seedRange to result
                result.Add(seedRange);
            }
            else if (mapSourceRange.From <= seedRange.From && seedRange.To <= mapSourceRange.To)
            {
                // Seed entirely fits into map => Shift range and add seed again
                var mapDestinationRange = map[mapSourceRange];
                var shift = mapDestinationRange.From - mapSourceRange.From;
                result.Add(new Range(seedRange.From + shift, seedRange.To + shift));
            }
            else if (seedRange.From < mapSourceRange.From)
            {
                // Seed starts before mapRange and ends inside mapRange
                todo.Enqueue(new Range(seedRange.From, mapSourceRange.From - 1));
                todo.Enqueue(new Range(mapSourceRange.From, seedRange.To));
            }
            else
            {
                // Seed starts inside mapRange and ends after mapRange
                todo.Enqueue(new Range(seedRange.From, mapSourceRange.To));
                todo.Enqueue(new Range(mapSourceRange.To + 1, seedRange.To));
            }
        }

        return result;
    }

    private bool InterSect(Range sourceRange, Range seed)
    {
        return sourceRange.From <= seed.To
            && seed.From <= sourceRange.To;
    }

    public long CalculateLowestLocationNumberFromSeedRanges()
    {
        return _maps
            .Aggregate(_seedRanges, Project)
            .Select(x => x.From)
            .Min();
    }

    private List<long> CreateSeeds(long from, long to)
    {
        var result = new List<long>();

        for (var i = from; i < to; i++)
        {
            result.Add(i);
        }

        return result;
    }
}

public record Range(long From, long To);
