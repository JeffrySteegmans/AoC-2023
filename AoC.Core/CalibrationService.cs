using System.Text.RegularExpressions;

namespace AoC.Core;

public interface ICalibrationService
{
    int CalculateCalibrationValue(List<string> encodedCalibration);
    int CalculateCalibrationValueWithSpelledOutNumbers(List<string> encodedCalibration);
}

public partial class CalibrationService : ICalibrationService
{
    private const string part1Regex = @"\d";
    private const string part2Regex = @"\d|one|two|three|four|five|six|seven|eight|nine";

    [GeneratedRegex(part1Regex)]
    private static partial Regex FirstSingleDigitNumber();

    [GeneratedRegex(part1Regex, RegexOptions.RightToLeft)]
    private static partial Regex LastSingleDigitNumber();

    [GeneratedRegex(part2Regex)]
    private static partial Regex FirstSingleDigitNumberWithSpelledNumbers();

    [GeneratedRegex(part2Regex, RegexOptions.RightToLeft)]
    private static partial Regex LastSingleDigitNumberWithSpelledNumbers();

    public int CalculateCalibrationValue(
        List<string> encodedCalibration)
    {
        var results = new List<int>();

        foreach (var encodedLine in encodedCalibration)
        {
            var decodedLine = DecodeLine(encodedLine);
            results.Add(decodedLine);
        }

        return results.Sum();
    }

    public int CalculateCalibrationValueWithSpelledOutNumbers(
        List<string> encodedCalibration)
    {
        var results = new List<int>();

        foreach (var encodedSpelledLine in encodedCalibration)
        {
            var decodedLine = DecodeLineWithSpelledNumbers(encodedSpelledLine);
            results.Add(decodedLine);
        }

        return results.Sum();
    }

    private int DecodeLine(string encodedLine)
    {
        var firstNumber = FirstSingleDigitNumber().Match(encodedLine).ToString();
        var lastNumber = LastSingleDigitNumber().Match(encodedLine).ToString();

        return ParseMatch(firstNumber) * 10 + ParseMatch(lastNumber);
    }

    private int DecodeLineWithSpelledNumbers(string encodedLine)
    {
        var firstNumber = FirstSingleDigitNumberWithSpelledNumbers().Match(encodedLine).ToString();
        var lastNumber = LastSingleDigitNumberWithSpelledNumbers().Match(encodedLine).ToString();

        return ParseMatch(firstNumber) * 10 + ParseMatch(lastNumber);
    }

    private int ParseMatch(string match) => match switch
    {
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        _ => int.Parse(match)
    };
}
