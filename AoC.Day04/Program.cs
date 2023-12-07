using AoC.Core.ScratchCards;

var input = (await File.ReadAllLinesAsync("input.txt")).ToList();
var service = new ScratchCardService(input);

Console.WriteLine("Day 04");
Console.WriteLine("------");

var part1 = service.CalculateTotalPoints();
Console.WriteLine("Part 1");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Result: {part1}");

var part2 = service.CalculateTotalCopies();
Console.WriteLine("Part 2");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Result: {part2}");
