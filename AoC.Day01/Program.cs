var calibrationService = new CalibrationService();

var input = (await File.ReadAllLinesAsync("input.txt")).ToList();

Console.WriteLine("Day 01");
Console.WriteLine("------");

var calibrationValue = calibrationService.CalculateCalibrationValue(input);
Console.WriteLine("Part 1");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Calibration value: {calibrationValue}");

var calibrationValueWithSpelledOutNumbers = calibrationService.CalculateCalibrationValueWithSpelledOutNumbers(input);
Console.WriteLine("Part 2");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Calibration value: {calibrationValueWithSpelledOutNumbers}");
