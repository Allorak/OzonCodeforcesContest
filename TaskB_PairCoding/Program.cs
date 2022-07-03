using System;
using System.Collections.Generic;
using System.Linq;

var setAmount = int.Parse(Console.ReadLine());
for (var i = 0; i < setAmount; i++)
{
    var employeeAmount = int.Parse(Console.ReadLine());
    var employeeStrengthLevels = Console.ReadLine().Split().Select(int.Parse).ToList();
    var employeeNumbers = new List<int>();
    for (var j = 0; j < employeeStrengthLevels.Count; j++)
    {
        employeeNumbers.Add(j+1);
    }

    while (employeeStrengthLevels.Any())
    {
        var bestPairIndex = 1;
        for (var j = 2; j < employeeStrengthLevels.Count; j++)
        {
            var minimumDifference = Math.Abs(employeeStrengthLevels[0] - employeeStrengthLevels[bestPairIndex]);
            var currentDifference = Math.Abs(employeeStrengthLevels[0] - employeeStrengthLevels[j]);
            if (currentDifference < minimumDifference)
                bestPairIndex = j;
        }

        Console.WriteLine($"{employeeNumbers[0]} {employeeNumbers[bestPairIndex]}");
        employeeNumbers.RemoveAt(bestPairIndex);
        employeeNumbers.RemoveAt(0);
        employeeStrengthLevels.RemoveAt(bestPairIndex);
        employeeStrengthLevels.RemoveAt(0);
    }

    Console.WriteLine();
}