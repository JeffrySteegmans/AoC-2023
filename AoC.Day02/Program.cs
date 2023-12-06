var input = (await File.ReadAllLinesAsync("input.txt")).ToList();
var gameService = new GameService(input);

Console.WriteLine("Day 02");
Console.WriteLine("------");

var sumFromValidGameIds = gameService.CalculateSumFromValidGameIds();
Console.WriteLine("Part 1");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Sum from valid Id's: {sumFromValidGameIds}");

var sumFromPower = gameService.CalculateSumFromPower();
Console.WriteLine("Part 2");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Sum from power: {sumFromPower}");
