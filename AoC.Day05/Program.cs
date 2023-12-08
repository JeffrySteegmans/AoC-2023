using AoC.Core.Almanac;

var input = await File.ReadAllTextAsync("input.txt");
var service = new AlmanacService(input);

Console.WriteLine("Day 05");
Console.WriteLine("------");

var part1 = service.CalculateLowestLocationNumber();
Console.WriteLine("Part 1");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Result: {part1}");

var part2 = service.CalculateLowestLocationNumberFromSeedRanges();
Console.WriteLine("Part 2");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Result: {part2}");
