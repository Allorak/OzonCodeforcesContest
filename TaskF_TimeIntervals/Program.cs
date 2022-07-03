using System;
using System.Collections.Generic;
using System.Linq;

var setAmount = int.Parse(Console.ReadLine());
for (var iteration = 0; iteration < setAmount; iteration++)
{
    var timeIntervalAmount = int.Parse(Console.ReadLine());
    var correctIntervals = true;
    var timeIntervals = new SortedDictionary<TimeOnly, TimeOnly>();
    for (var i = 0; i < timeIntervalAmount; i++)
    {
        var timeIntervalAsString = Console.ReadLine().Split('-');
        var (beginTimeStampAsString, endTimeStampAsString) = (timeIntervalAsString[0], timeIntervalAsString[1]);
        if (!TimeOnly.TryParse(beginTimeStampAsString, out var beginTimeStamp) ||
            !TimeOnly.TryParse(endTimeStampAsString, out var endTimeStamp))
            correctIntervals = false;
        if (beginTimeStamp > endTimeStamp)
            correctIntervals = false;
        if (timeIntervals.ContainsKey(beginTimeStamp))
            correctIntervals = false;
        else
            timeIntervals[beginTimeStamp] = endTimeStamp;
    }

    var beginTimes = timeIntervals.Keys.ToList();
    var endTimes = timeIntervals.Values.ToList();
    for (var i = 0; correctIntervals && i < beginTimes.Count-1; i++)
    {
        if (beginTimes[i + 1] <= endTimes[i])
            correctIntervals = false;
    }
    Console.WriteLine(correctIntervals ? "YES" : "NO");
}