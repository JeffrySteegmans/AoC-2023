using AoC.Core.Gondola;

var input = (await File.ReadAllLinesAsync("input.txt")).ToList();
var engineService = new EngineService(input);

Console.WriteLine("Day 02");
Console.WriteLine("------");

var part1 = engineService.CalculatePartNumberSum();
Console.WriteLine("Part 1");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Result: {part1}");

var part2 = engineService.CalculateSumOfGearRatios();
Console.WriteLine("Part 2");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Result: {part2}");
