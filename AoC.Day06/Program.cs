using AoC.Core.BoatRace;

var input = (await File.ReadAllLinesAsync("input.txt")).ToList();
var service = new BoatRaceService(input);

Console.WriteLine("Day 06");
Console.WriteLine("------");

var part1 = service.CalculateMultiplicationOfNumberOfWaysToBeatTheRecord();
Console.WriteLine("Part 1");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Result: {part1}");

var part2 = service.CalculateNumberOfWaysToBeatTheRecord();
Console.WriteLine("Part 2");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Result: {part2}");
