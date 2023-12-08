using System.Text.RegularExpressions;

namespace AoC.Core.BoatRace;

public interface IBoatRaceService
{
    int CalculateMultiplicationOfNumberOfWaysToBeatTheRecord();

    int CalculateNumberOfWaysToBeatTheRecord();
}

public partial class BoatRaceService
    : IBoatRaceService
{
    [GeneratedRegex(@"(\d+)")]
    private static partial Regex NumberRegex();

    private readonly List<Race> _races = [];
    private readonly Race race;

    public BoatRaceService(List<string> input)
    {
        var times = NumberRegex()
            .Matches(input.First())
            .Select(x => int.Parse(x.Value))
            .ToArray();

        _races = NumberRegex()
            .Matches(input.Last())
            .Select(x => long.Parse(x.Value))
            .Select((distance, index) => new Race(times[index], distance))
            .ToList();

        var time = NumberRegex()
            .Matches(input.First().Replace(" ", ""))
            .Select(x => int.Parse(x.Value))
            .Single();

        var recordDistance = NumberRegex()
            .Matches(input.Last().Replace(" ", ""))
            .Select(x => long.Parse(x.Value))
            .Single();

        race = new Race(time, recordDistance);
    }

    public int CalculateMultiplicationOfNumberOfWaysToBeatTheRecord()
    {
        return _races
            .Select(CountNumberOfWaysToBeatTheRecord)
            .Aggregate((seed, numberOfWaysToBeatRaceRecordDistance) => seed * numberOfWaysToBeatRaceRecordDistance);
    }

    public int CalculateNumberOfWaysToBeatTheRecord()
    {
        return CountNumberOfWaysToBeatTheRecord(race);
    }

    private int CountNumberOfWaysToBeatTheRecord(Race race)
    {
        return Enumerable.Range(0, race.Time)
                    .Select(x => (long)x)
                    .Select(milliSeconds => milliSeconds * (race.Time - milliSeconds))
                    .Where(distance => distance > race.RecordDistance)
                    .Count();
    }
}

public record Race(int Time, long RecordDistance);
